using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingSign.Model
{
    static class Program
    {
        static void Main()
        {
            using(var db = new MeetingSignModel())
            {
                db.MeetingRooms.Add(new Entity.MeetingRoom() { id = 1 });
                db.SaveChanges();
            }
        }
    }
}
