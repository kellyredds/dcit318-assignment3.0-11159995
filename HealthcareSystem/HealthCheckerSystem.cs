using System;
using System.Collections.Generic;
using System.Linq;
using HealthcareSystem.Models;
using HealthcareSystem.Repositories;

namespace HealthcareSystem
{
    public class HealthCheckerSystem
    {
        // Repositories for Patients and Prescriptions
        private readonly Repository<Patient> _patientRepo = new();
        private readonly Repository<Prescription> _prescriptionRepo = new();
        private Dictionary<int, List<Prescription>> _prescriptionMap = new();

        public void SeedData()
        {
            // Addition of patients
            _patientRepo.Add(new Patient(1, "Johnny Depp", 43, "Male"));
            _patientRepo.Add(new Patient(2, "Kate Beckinsale", 38, "Female"));
            _patientRepo.Add(new Patient(3, "Snoop Dogg", 55, "Male"));

            // Add prescriptions
            _prescriptionRepo.Add(new Prescription(101, 1, "Chloroquine", DateTime.Now.AddDays(-5)));
            _prescriptionRepo.Add(new Prescription(102, 1, "Amoxicillin", DateTime.Now.AddDays(-3)));
            _prescriptionRepo.Add(new Prescription(103, 2, "Collodium", DateTime.Now.AddDays(-3)));
            _prescriptionRepo.Add(new Prescription(104, 3, "Aspirin", DateTime.Now.AddDays(-3)));
            _prescriptionRepo.Add(new Prescription(105, 3, "Atorvastatin", DateTime.Now));
        }

        public void BuildPrescriptionMap()
        {
            _prescriptionMap = _prescriptionRepo.GetAll()
                .GroupBy(p => p.PatientId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public void PrintAllPatients()
        {
            Console.WriteLine("\n=== PATIENT LIST ===");
            foreach (var patient in _patientRepo.GetAll())
            {
                Console.WriteLine(patient);
            }
        }

        public void PrintPrescriptionsForPatient(int patientId)
        {
            if (_prescriptionMap.TryGetValue(patientId, out var prescriptions))
            {
                var patient = _patientRepo.GetById(p => p.Id == patientId);
                Console.WriteLine($"\n=== PRESCRIPTIONS FOR {patient?.Name.ToUpper()} ===");
                foreach (var prescription in prescriptions)
                {
                    Console.WriteLine(prescription);
                }
            }
            else
            {
                Console.WriteLine($"No prescriptions found for Patient ID: {patientId}");
            }
        }
    }
}