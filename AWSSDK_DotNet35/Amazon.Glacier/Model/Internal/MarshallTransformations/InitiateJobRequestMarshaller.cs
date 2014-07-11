/*
 * Copyright 2010-2014 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using Amazon.Glacier.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Json.LitJson;

namespace Amazon.Glacier.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Initiate Job Request Marshaller
    /// </summary>       
    internal class InitiateJobRequestMarshaller : IMarshaller<IRequest, InitiateJobRequest> 
    {
        

        public IRequest Marshall(InitiateJobRequest initiateJobRequest) 
        {

            IRequest request = new DefaultRequest(initiateJobRequest, "AmazonGlacier");
            string target = "Glacier.InitiateJob";
            request.Headers["X-Amz-Target"] = target;
            
            request.Headers["Content-Type"] = "application/x-amz-json-1.0";
            request.HttpMethod = "POST";
            string uriResourcePath = "/{accountId}/vaults/{vaultName}/jobs"; 
            if(initiateJobRequest.IsSetAccountId())
                uriResourcePath = uriResourcePath.Replace("{accountId}", StringUtils.FromString(initiateJobRequest.AccountId) ); 
            else
                uriResourcePath = uriResourcePath.Replace("{accountId}", "" ); 
            if(initiateJobRequest.IsSetVaultName())
                uriResourcePath = uriResourcePath.Replace("{vaultName}", StringUtils.FromString(initiateJobRequest.VaultName) ); 
            else
                uriResourcePath = uriResourcePath.Replace("{vaultName}", "" ); 
            request.ResourcePath = uriResourcePath;
            
             
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                JsonWriter writer = new JsonWriter(stringWriter);
                writer.WriteObjectStart();
                
                if (initiateJobRequest.JobParameters != null && initiateJobRequest.JobParameters.IsSetFormat()) 
                {
                    writer.WritePropertyName("Format");
                    writer.Write(initiateJobRequest.JobParameters.Format);
                }
                if (initiateJobRequest.JobParameters != null && initiateJobRequest.JobParameters.IsSetType()) 
                {
                    writer.WritePropertyName("Type");
                    writer.Write(initiateJobRequest.JobParameters.Type);
                }
                if (initiateJobRequest.JobParameters != null && initiateJobRequest.JobParameters.IsSetArchiveId()) 
                {
                    writer.WritePropertyName("ArchiveId");
                    writer.Write(initiateJobRequest.JobParameters.ArchiveId);
                }
                if (initiateJobRequest.JobParameters != null && initiateJobRequest.JobParameters.IsSetDescription()) 
                {
                    writer.WritePropertyName("Description");
                    writer.Write(initiateJobRequest.JobParameters.Description);
                }
                if (initiateJobRequest.JobParameters != null && initiateJobRequest.JobParameters.IsSetSNSTopic()) 
                {
                    writer.WritePropertyName("SNSTopic");
                    writer.Write(initiateJobRequest.JobParameters.SNSTopic);
                }
                if (initiateJobRequest.JobParameters != null && initiateJobRequest.JobParameters.IsSetRetrievalByteRange()) 
                {
                    writer.WritePropertyName("RetrievalByteRange");
                    writer.Write(initiateJobRequest.JobParameters.RetrievalByteRange);
                }

                if (initiateJobRequest.JobParameters != null) 
                {
                    InventoryRetrievalJobInput inventoryRetrievalParameters = initiateJobRequest.JobParameters.InventoryRetrievalParameters;
                    if (inventoryRetrievalParameters != null)
                    {
                        writer.WritePropertyName("InventoryRetrievalParameters");
                        writer.WriteObjectStart();
                        if (inventoryRetrievalParameters != null && inventoryRetrievalParameters.IsSetStartDate()) 
                        {
                            writer.WritePropertyName("StartDate");
                            writer.Write(inventoryRetrievalParameters.StartDate);
                        }
                        if (inventoryRetrievalParameters != null && inventoryRetrievalParameters.IsSetEndDate()) 
                        {
                            writer.WritePropertyName("EndDate");
                            writer.Write(inventoryRetrievalParameters.EndDate);
                        }
                        if (inventoryRetrievalParameters != null && inventoryRetrievalParameters.IsSetLimit()) 
                        {
                            writer.WritePropertyName("Limit");
                            writer.Write(inventoryRetrievalParameters.Limit);
                        }
                        if (inventoryRetrievalParameters != null && inventoryRetrievalParameters.IsSetMarker()) 
                        {
                            writer.WritePropertyName("Marker");
                            writer.Write(inventoryRetrievalParameters.Marker);
                        }
                        writer.WriteObjectEnd();
                    }
                }

                writer.WriteObjectEnd();
                
                string snippet = stringWriter.ToString();
                request.Content = System.Text.Encoding.UTF8.GetBytes(snippet);
            }
        

            return request;
        }
    }
}