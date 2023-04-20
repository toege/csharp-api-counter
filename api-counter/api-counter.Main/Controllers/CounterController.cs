using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_counter.Controllers
{
    // Object representing a counter. Based on the requirements
    public class Counter
    {
        public Counter() { }
        // @TODO Create int property called Value holding the counter value
        // @EXTENSIONS @TODO Create string property called Name holding the counter name 
    }

    [ApiController]
    [Route("[controller]")]
    public class CounterController : ControllerBase
    {
        // @TODO We need to create an object holding our counter object. The name of the object variable needs to be counter

        // @EXTENSIONS @TODO We need to create a list holding Counter objects. The variable needs to be called counters

        public CounterController()
        {
            // @TODO create a new counter on class construction

            // @EXTENSIONS @TODO make sure you initialize the List of counters
        }

        // @TODO Write your decorators & function here that will be called when accessing the specific endpoints.
    }
}
