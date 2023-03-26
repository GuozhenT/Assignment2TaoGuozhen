using Microsoft.EntityFrameworkCore;

namespace Assignment2TaoGuozhen.Data.ViewModels
{
    [Keyless]
    public class Contact
    {
        public string Email{ get; set; }

        public string Name { get; set; }


        public string Message { get; set; }
    }
}
