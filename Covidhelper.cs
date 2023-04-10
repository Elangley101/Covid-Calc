using System;

class Helper
{
    private double temperature; // in Celsius
    private string symptoms;
    private bool exposure;
    private bool contact; // if COVID contact

    public double TemperatureCelsius
    {
        get => temperature;
        set => temperature = value;
    }

    public double TemperatureFahrenheit
    {
        get => 1.8 * temperature + 32;
        set => temperature = (value - 32) / 1.8;
    }

    public string Symptoms
    {
        get => symptoms;
        set => symptoms = value;
    }

    public bool Exposure
    {
        get => exposure;
        set => exposure = value;
    }

    public bool Contact
    {
        get => contact;
        set => contact = value;
    }

    public bool RiskFactor => temperature > 37 || symptoms.Contains("pain ") && symptoms.Contains("cough ") || exposure;


    static void Main(string[] args)
    {
        Helper helper = new Helper();
        System.Console.WriteLine("Measure your body temperature");
        System.Console.Write("Type C for Celsius or F for Fahrenheit: ");
        string unit = System.Console.ReadLine();
        System.Console.Write("Input your measured temperature: ");
        double temperature = Double.Parse(System.Console.ReadLine());
        if (unit.ToUpper() == "C")
            helper.TemperatureCelsius = temperature;
        else
            helper.TemperatureFahrenheit = temperature;
        System.Console.WriteLine("Your temperature: {0} C = {1} F", helper.TemperatureCelsius, helper.TemperatureFahrenheit);
        System.Console.WriteLine("You {0}have a fewer", helper.TemperatureCelsius > 37 ? "" : "don't ");
        helper.Symptoms = "";
        System.Console.Write("Do you have pain (Y/N)? ");
        if (System.Console.ReadLine().ToUpper() == "Y")
            helper.Symptoms += "pain ";
        System.Console.Write("Do you have cough (Y/N)? ");
        if (System.Console.ReadLine().ToUpper() == "Y")
            helper.Symptoms += "cough ";
        System.Console.Write("Have you been recently in contact with someone with COVID (Y/N)? ");
        helper.Contact = System.Console.ReadLine().ToUpper() == "Y";
        System.Console.Write("Do you have exposure (Y/N)? ");
        helper.Exposure = System.Console.ReadLine().ToUpper() == "Y";
        if (helper.RiskFactor)
            System.Console.WriteLine("We recommend you to contact the local health department");
        else
            System.Console.WriteLine("Everything looks OK so far (remember safety guidelines)");
    }
}
