using System;
using System.Runtime.Serialization;
using System.Security.Principal;

namespace DiscountMe.Infrastructure {
    [Serializable]
    class CustomIdentity : IIdentity, ISerializable {
        public CustomIdentity(string name, string id) {
            IsAuthenticated = true;
            Name = name;
            if (!string.IsNullOrWhiteSpace(id))
                Id = int.Parse(id);
            AuthenticationType = "Forms";
        }

        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public string Name { get; private set; }
        public int Id { get; private set; }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            if (context.State == StreamingContextStates.CrossAppDomain) {
                var gIdent = new GenericIdentity(Name, AuthenticationType);
                info.SetType(gIdent.GetType());
                var serializableMembers = FormatterServices.GetSerializableMembers(gIdent.GetType());
                var serializableValues = FormatterServices.GetObjectData(gIdent, serializableMembers);
                for (var i = 0; i < serializableMembers.Length; i++) {
                    info.AddValue(serializableMembers[i].Name, serializableValues[i]);
                }
            }
            else {
                throw new InvalidOperationException("Serialization not supported");
            }
        }
    }
}