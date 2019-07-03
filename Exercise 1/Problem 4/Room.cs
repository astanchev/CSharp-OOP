namespace P04_Hospital
{
    using System.Collections.Generic;

    public class Room
    {
        private List<Patient> patients;

        public Room()
        {
            this.patients = new List<Patient>();
        }

        public int Count => patients.Count;
        public bool AddPatient(Patient patient)
        {
            if (this.Count < 3)
            {
                patients.Add(patient);
                return true;
            }

            return false;
        }

        public List<Patient> GetPatients() => this.patients;
    }
}