using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

var settings = new JsonSerializerSettings()
               {
	               Converters = new List<JsonConverter>
	                            {
		                            new StringEnumConverter()
	                            }
               };

//var value = BPS_TaxationModel.OnWinnings | BPS_TaxationModel.OnStake;
var value = BPS_TaxationModel.OnWinnings;

var @string = JsonConvert.SerializeObject(value);

Console.WriteLine($"Serialized Enum: {@string}");

var deserialized = JsonConvert.DeserializeObject<TaxationModel>(@string);

Console.WriteLine($"Deserialization on BA side: {deserialized}");

var list = (deserialized switch
{
    TaxationModel.NotRelevantOld => new[] {TaxationModel.NotRelevant},
    TaxationModel.OnStakeOld => new[] {TaxationModel.OnStake},
    TaxationModel.OnWinningsOld => new[] {TaxationModel.OnWinnings},
    _ => GetFlags()
}).Select(x => x.ToString());

//var list = deserialized.GetFlags().Select(RemoveOldSuffix);


foreach (var item in list)
{
    Console.WriteLine(item);
}


Console.ReadLine();



IEnumerable<TaxationModel> GetFlags()
{
    if (deserialized.HasFlag(TaxationModel.OnStake))
    {
        yield return TaxationModel.OnStake;
    }



    if (deserialized.HasFlag(TaxationModel.OnWinnings))
    {
        yield return TaxationModel.OnWinnings;
    }



    if (deserialized.HasFlag(TaxationModel.NotRelevant))
    {
        yield return TaxationModel.NotRelevant;
    }
}

string RemoveOldSuffix(TaxationModel taxationModel)
{
    var taxationModelString = taxationModel.ToString();
    return taxationModelString.Contains("Old") ? taxationModelString.Replace("Old", string.Empty) : taxationModelString;
}

//OLD
public enum BPS_TaxationModel
{
    OnStake,
    OnWinnings,
    NotRelevant
}


//NEW
//[Flags]
//public enum BPS_TaxationModel
//{
//    OnStakeOld = 0,
//    OnWinningsOld = 1,
//    NotRelevantOld = 2,
//    OnStake = 1 << 2,
//    OnWinnings = 1 << 3,
//    NotRelevant = 1 << 4
//}


[Flags]
public enum TaxationModel
{
    OnStakeOld = 0,
    OnWinningsOld = 1,
    NotRelevantOld = 2,
    OnStake = 1 << 2,
    OnWinnings = 1 << 3,
    NotRelevant = 1 << 4
}