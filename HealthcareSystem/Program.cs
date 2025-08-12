using HealthcareSystem;

var app = new HealthCheckerSystem();

// Initializing data
app.SeedData();
app.BuildPrescriptionMap();

// Display of results
app.PrintAllPatients();

app.PrintPrescriptionsForPatient(1);

