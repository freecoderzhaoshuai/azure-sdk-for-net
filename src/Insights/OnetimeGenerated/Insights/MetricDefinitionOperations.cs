// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

// IMPORTANT: This code was machine generated and then modified by humans.
// Updating this file with the machine generated one might overwrite important changes. 
// Please review and revert unintended changes carefully.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Hyak.Common;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// Operations for metric definitions.
    /// </summary>
    internal partial class MetricDefinitionOperations : IServiceOperations<InsightsClient>, IMetricDefinitionOperations
    {
        /// <summary>
        /// Initializes a new instance of the MetricDefinitionOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal MetricDefinitionOperations(InsightsClient client)
        {
            this._client = client;
        }
        
        private InsightsClient _client;
        
        /// <summary>
        /// Gets a reference to the Microsoft.Azure.Insights.InsightsClient.
        /// </summary>
        public InsightsClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// The List Metric Definitions operation lists the metric definitions
        /// for the resource.
        /// </summary>
        /// <param name='resourceUri'>
        /// Required. The resource identifier of the target resource to get
        /// metrics for.
        /// </param>
        /// <param name='filterString'>
        /// Optional. An OData $filter expression that supports querying by the
        /// name of the metric definition. For example, "name.value eq
        /// 'Percentage CPU'". Name is optional, meaning the expression may be
        /// "".
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List Metric Definitions operation response.
        /// </returns>
        public async Task<MetricDefinitionListResponse> GetMetricDefinitionsInternalAsync(string resourceUri, string filterString, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceUri == null)
            {
                throw new ArgumentNullException("resourceUri");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceUri", resourceUri);
                tracingParameters.Add("filterString", filterString);
                TracingAdapter.Enter(invocationId, this, "GetMetricDefinitionsAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/";
            url = url + resourceUri;
            url = url + "/metricDefinitions?";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2014-04-01");
            List<string> odataFilter = new List<string>();
            if (filterString != null)
            {
                odataFilter.Add(Uri.EscapeDataString(filterString));
            }
            if (odataFilter.Count > 0)
            {
                queryParameters.Add("$filter=" + string.Join(null, odataFilter));
            }
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept", "application/json");
                httpRequest.Headers.Add("x-ms-version", "2014-04-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    MetricDefinitionListResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new MetricDefinitionListResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            MetricDefinitionCollection metricDefinitionCollectionInstance = new MetricDefinitionCollection();
                            result.MetricDefinitionCollection = metricDefinitionCollectionInstance;
                            
                            JToken valueArray = responseDoc["value"];
                            if (valueArray != null && valueArray.Type != JTokenType.Null)
                            {
                                foreach (JToken valueValue in ((JArray)valueArray))
                                {
                                    MetricDefinition metricDefinitionInstance = new MetricDefinition();
                                    metricDefinitionCollectionInstance.Value.Add(metricDefinitionInstance);
                                    
                                    JToken nameValue = valueValue["name"];
                                    if (nameValue != null && nameValue.Type != JTokenType.Null)
                                    {
                                        LocalizableString nameInstance = new LocalizableString();
                                        metricDefinitionInstance.Name = nameInstance;
                                        
                                        JToken valueValue2 = nameValue["value"];
                                        if (valueValue2 != null && valueValue2.Type != JTokenType.Null)
                                        {
                                            string valueInstance = ((string)valueValue2);
                                            nameInstance.Value = valueInstance;
                                        }
                                        
                                        JToken localizedValueValue = nameValue["localizedValue"];
                                        if (localizedValueValue != null && localizedValueValue.Type != JTokenType.Null)
                                        {
                                            string localizedValueInstance = ((string)localizedValueValue);
                                            nameInstance.LocalizedValue = localizedValueInstance;
                                        }
                                    }
                                    
                                    JToken unitValue = valueValue["unit"];
                                    if (unitValue != null && unitValue.Type != JTokenType.Null)
                                    {
                                        Unit unitInstance = ((Unit)Enum.Parse(typeof(Unit), ((string)unitValue), true));
                                        metricDefinitionInstance.Unit = unitInstance;
                                    }
                                    
                                    JToken primaryAggregationTypeValue = valueValue["primaryAggregationType"];
                                    if (primaryAggregationTypeValue != null && primaryAggregationTypeValue.Type != JTokenType.Null)
                                    {
                                        AggregationType primaryAggregationTypeInstance = ((AggregationType)Enum.Parse(typeof(AggregationType), ((string)primaryAggregationTypeValue), true));
                                        metricDefinitionInstance.PrimaryAggregationType = primaryAggregationTypeInstance;
                                    }
                                    
                                    JToken resourceUriValue = valueValue["resourceUri"];
                                    if (resourceUriValue != null && resourceUriValue.Type != JTokenType.Null)
                                    {
                                        string resourceUriInstance = ((string)resourceUriValue);
                                        metricDefinitionInstance.ResourceUri = resourceUriInstance;
                                    }
                                    
                                    JToken metricAvailabilitiesArray = valueValue["metricAvailabilities"];
                                    if (metricAvailabilitiesArray != null && metricAvailabilitiesArray.Type != JTokenType.Null)
                                    {
                                        foreach (JToken metricAvailabilitiesValue in ((JArray)metricAvailabilitiesArray))
                                        {
                                            MetricAvailability metricAvailabilityInstance = new MetricAvailability();
                                            metricDefinitionInstance.MetricAvailabilities.Add(metricAvailabilityInstance);
                                            
                                            JToken timeGrainValue = metricAvailabilitiesValue["timeGrain"];
                                            if (timeGrainValue != null && timeGrainValue.Type != JTokenType.Null)
                                            {
                                                TimeSpan timeGrainInstance = XmlConvert.ToTimeSpan(((string)timeGrainValue));
                                                metricAvailabilityInstance.TimeGrain = timeGrainInstance;
                                            }
                                            
                                            JToken retentionValue = metricAvailabilitiesValue["retention"];
                                            if (retentionValue != null && retentionValue.Type != JTokenType.Null)
                                            {
                                                TimeSpan retentionInstance = XmlConvert.ToTimeSpan(((string)retentionValue));
                                                metricAvailabilityInstance.Retention = retentionInstance;
                                            }
                                            
                                            JToken locationValue = metricAvailabilitiesValue["location"];
                                            if (locationValue != null && locationValue.Type != JTokenType.Null)
                                            {
                                                MetricLocation locationInstance = new MetricLocation();
                                                metricAvailabilityInstance.Location = locationInstance;
                                                
                                                JToken tableEndpointValue = locationValue["tableEndpoint"];
                                                if (tableEndpointValue != null && tableEndpointValue.Type != JTokenType.Null)
                                                {
                                                    string tableEndpointInstance = ((string)tableEndpointValue);
                                                    locationInstance.TableEndpoint = tableEndpointInstance;
                                                }
                                                
                                                JToken tableInfoArray = locationValue["tableInfo"];
                                                if (tableInfoArray != null && tableInfoArray.Type != JTokenType.Null)
                                                {
                                                    foreach (JToken tableInfoValue in ((JArray)tableInfoArray))
                                                    {
                                                        MetricTableInfo metricTableInfoInstance = new MetricTableInfo();
                                                        locationInstance.TableInfo.Add(metricTableInfoInstance);
                                                        
                                                        JToken tableNameValue = tableInfoValue["tableName"];
                                                        if (tableNameValue != null && tableNameValue.Type != JTokenType.Null)
                                                        {
                                                            string tableNameInstance = ((string)tableNameValue);
                                                            metricTableInfoInstance.TableName = tableNameInstance;
                                                        }
                                                        
                                                        JToken startTimeValue = tableInfoValue["startTime"];
                                                        if (startTimeValue != null && startTimeValue.Type != JTokenType.Null)
                                                        {
                                                            DateTime startTimeInstance = ((DateTime)startTimeValue);
                                                            metricTableInfoInstance.StartTime = startTimeInstance;
                                                        }
                                                        
                                                        JToken endTimeValue = tableInfoValue["endTime"];
                                                        if (endTimeValue != null && endTimeValue.Type != JTokenType.Null)
                                                        {
                                                            DateTime endTimeInstance = ((DateTime)endTimeValue);
                                                            metricTableInfoInstance.EndTime = endTimeInstance;
                                                        }
                                                        
                                                        JToken sasTokenValue = tableInfoValue["sasToken"];
                                                        if (sasTokenValue != null && sasTokenValue.Type != JTokenType.Null)
                                                        {
                                                            string sasTokenInstance = ((string)sasTokenValue);
                                                            metricTableInfoInstance.SasToken = sasTokenInstance;
                                                        }
                                                        
                                                        JToken sasTokenExpirationTimeValue = tableInfoValue["sasTokenExpirationTime"];
                                                        if (sasTokenExpirationTimeValue != null && sasTokenExpirationTimeValue.Type != JTokenType.Null)
                                                        {
                                                            DateTime sasTokenExpirationTimeInstance = ((DateTime)sasTokenExpirationTimeValue);
                                                            metricTableInfoInstance.SasTokenExpirationTime = sasTokenExpirationTimeInstance;
                                                        }
                                                    }
                                                }
                                                
                                                JToken partitionKeyValue = locationValue["partitionKey"];
                                                if (partitionKeyValue != null && partitionKeyValue.Type != JTokenType.Null)
                                                {
                                                    string partitionKeyInstance = ((string)partitionKeyValue);
                                                    locationInstance.PartitionKey = partitionKeyInstance;
                                                }
                                            }
                                        }
                                    }
                                    
                                    JToken propertiesSequenceElement = ((JToken)valueValue["properties"]);
                                    if (propertiesSequenceElement != null && propertiesSequenceElement.Type != JTokenType.Null)
                                    {
                                        foreach (JProperty property in propertiesSequenceElement)
                                        {
                                            string propertiesKey = ((string)property.Name);
                                            string propertiesValue = ((string)property.Value);
                                            metricDefinitionInstance.Properties.Add(propertiesKey, propertiesValue);
                                        }
                                    }
                                    
                                    JToken dimensionsArray = valueValue["dimensions"];
                                    if (dimensionsArray != null && dimensionsArray.Type != JTokenType.Null)
                                    {
                                        foreach (JToken dimensionsValue in ((JArray)dimensionsArray))
                                        {
                                            Dimension dimensionInstance = new Dimension();
                                            metricDefinitionInstance.Dimensions.Add(dimensionInstance);
                                            
                                            JToken nameValue2 = dimensionsValue["name"];
                                            if (nameValue2 != null && nameValue2.Type != JTokenType.Null)
                                            {
                                                LocalizableString nameInstance2 = new LocalizableString();
                                                dimensionInstance.Name = nameInstance2;
                                                
                                                JToken valueValue3 = nameValue2["value"];
                                                if (valueValue3 != null && valueValue3.Type != JTokenType.Null)
                                                {
                                                    string valueInstance2 = ((string)valueValue3);
                                                    nameInstance2.Value = valueInstance2;
                                                }
                                                
                                                JToken localizedValueValue2 = nameValue2["localizedValue"];
                                                if (localizedValueValue2 != null && localizedValueValue2.Type != JTokenType.Null)
                                                {
                                                    string localizedValueInstance2 = ((string)localizedValueValue2);
                                                    nameInstance2.LocalizedValue = localizedValueInstance2;
                                                }
                                            }
                                            
                                            JToken valuesArray = dimensionsValue["values"];
                                            if (valuesArray != null && valuesArray.Type != JTokenType.Null)
                                            {
                                                foreach (JToken valuesValue in ((JArray)valuesArray))
                                                {
                                                    LocalizableString localizableStringInstance = new LocalizableString();
                                                    dimensionInstance.Values.Add(localizableStringInstance);
                                                    
                                                    JToken valueValue4 = valuesValue["value"];
                                                    if (valueValue4 != null && valueValue4.Type != JTokenType.Null)
                                                    {
                                                        string valueInstance3 = ((string)valueValue4);
                                                        localizableStringInstance.Value = valueInstance3;
                                                    }
                                                    
                                                    JToken localizedValueValue3 = valuesValue["localizedValue"];
                                                    if (localizedValueValue3 != null && localizedValueValue3.Type != JTokenType.Null)
                                                    {
                                                        string localizedValueInstance3 = ((string)localizedValueValue3);
                                                        localizableStringInstance.LocalizedValue = localizedValueInstance3;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
