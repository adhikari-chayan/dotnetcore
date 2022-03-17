using ProtoBuf;

namespace Readers.Api.Models
{
    [ProtoContract]
    public class Reader
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string UserName { get; set; }
        [ProtoMember(3)]    
        public string EmailAddress { get; set; }
    }
}
