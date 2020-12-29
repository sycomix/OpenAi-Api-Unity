using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using UnityEngine;

namespace OpenAi.Api.V1
{
    public class OpenAiApiV1 : IApiResource
    {
        private SAuthArgs _authArgs;

        public IApiResource ParentResource => null;

        public string Endpoint => "https://api.openai.com/v1";

        public string Url => Endpoint;

        public EnginesResource Engines { get; private set; }

        public OpenAiApiV1(SAuthArgs authArgs)
        {
            _authArgs = authArgs;
            Engines = new EnginesResource(this);
        }

        public void ConstructEndpoint(StringBuilder sb)
        {
            sb.Append(Endpoint);
        }

        public void PopulateAuthHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authArgs.private_auth_key);
            client.DefaultRequestHeaders.Add("User-Agent", "hexthedev/openai_api_unity");
            if(_authArgs.organization != null) client.DefaultRequestHeaders.Add("OpenAI-Organization", _authArgs.organization);
        }

        public void PopulateAuthHeaders(HttpRequestMessage message)
        {
            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authArgs.private_auth_key);
            message.Headers.Add("User-Agent", "hexthedev/openai_api_unity");
            if (_authArgs.organization != null) message.Headers.Add("OpenAI-Organization", _authArgs.organization);
        }
    }
}