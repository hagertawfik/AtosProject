using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Channels;
namespace APIs_layer.Controllers
{
    [Authorize(Roles = "student")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubmitExamController : ControllerBase
    {
        

        [HttpPost]
        public IActionResult SubmitExam(SubmitExamRequestDto submitExamDto)
        {
            try
            {
                
                var studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                submitExamDto.StudentId = studentId;
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);


                ConnectionFactory factory = new();
                factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
                factory.ClientProvidedName = "examSubmitionQueue";
                IConnection cnn = factory.CreateConnection();
                IModel channel = cnn.CreateModel();

                string exchangeName = "EvelutionExchange";
                string routingKey = "Evelution-routing-key";
                string queueName = "EvelutionQueue";

                channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                channel.QueueDeclare(queueName, false, false, false, null);
                channel.QueueBind(queueName, exchangeName, routingKey, null);

                string serializedMessage = JsonConvert.SerializeObject(submitExamDto);
                byte[] messageBodyBytes = Encoding.UTF8.GetBytes(serializedMessage);
                channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);
             
                channel.Close();
                cnn.Close();

                return Ok("Exam submitted successfuly");
            }

            catch (Exception ex) { return BadRequest(ex.Message); }

        }


      
    }
}
