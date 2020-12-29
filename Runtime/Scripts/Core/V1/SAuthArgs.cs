﻿using OpenAi.Json;

using System;

namespace OpenAi.Api.V1
{
    public struct SAuthArgs : IJsonable
    {
        public string private_auth_key;
        public string organization;

        public void FromJson(JsonObject jsonObj)
        {
            if (jsonObj.Type != EJsonType.Object) throw new Exception("Must be an object");

            foreach (JsonObject jo in jsonObj.NestedValues)
            {
                switch (jo.Name)
                {
                    case nameof(private_auth_key):
                        private_auth_key = jo.StringValue;
                        break;
                    case nameof(organization):
                        organization = jo.StringValue;
                        break;
                }
            }
        }

        public string ToJson()
        {
            JsonBuilder jb = new JsonBuilder();

            jb.StartObject();
            jb.Add(nameof(private_auth_key), private_auth_key);
            jb.Add(nameof(organization), organization);
            jb.EndObject();

            return jb.ToString();
        }
    }
}