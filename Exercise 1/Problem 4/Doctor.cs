namespace P04_Hospital
{
    using System.Collections.Generic;
    public class Doctor
    {
        private List<Patient> patients;

        public Doctor(string name)
        {
            this.patients = new List<Patient>();
            this.Name = name;
        }
        public string Name { get; private set; }

        public void AddPatient(Patient patient)
        {
            this.patients.Add(patient);
        }

        public List<Patient> GetPatients() => this.patients;
    }
}