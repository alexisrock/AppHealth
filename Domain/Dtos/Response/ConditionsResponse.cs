using Domain.Commonds;


namespace Domain.Dtos.Response;
public class ConditionsResponse: BaseResponse
{
    public List<Conditions>? conditions { get; set; }

}

public class Conditions
{

    public string id { get; set; } = string.Empty;
    public string name { get; set; } = string.Empty;
    public string common_name { get; set; } = string.Empty;
    public string sex_filter { get; set; } = string.Empty;
    public List<string>? categories { get; set; }
    public string prevalence { get; set; } = string.Empty;
    public string acuteness { get; set; } = string.Empty;
    public string severity { get; set; } = string.Empty;
    public Extras? extras { get; set; }
    public string triage_level { get; set; } = string.Empty;
    public string recommended_channel { get; set; } = string.Empty;

}


public class Extras
{
    public string icd10_code { get; set; } = string.Empty;
    public string hint { get; set; } = string.Empty;
}
