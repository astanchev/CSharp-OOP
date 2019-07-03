namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Department
    {
        private List<Room> rooms;

        public Department(string name)
        {
            this.rooms = new List<Room>();
            for (int roomNumber = 0; roomNumber < 20; roomNumber++)
            {
               rooms.Add(new Room());
            }
            this.Name = name;
        }
        public string Name { get; private set; }

        public void AddPatient(Patient patient)
        {
            if (this.rooms.Sum(r => r.Count) < 60)
            {
                foreach (var room in rooms)
                {
                    if (room.AddPatient(patient))
                    {
                        break;
                    }
                }
            }
        }

        public List<Room> GetRooms() => this.rooms;
    }
}