using Microsoft.AspNet.Identity;
using System;
using Mshudx.AspNet.Identity.DocumentDb;

// ReSharper disable once CheckNamespace
namespace Microsoft.Framework.DependencyInjection
{
    public static class IdentityDocumentDbBuilderExtensions
    {
        public static IdentityBuilder AddDocumentDbStores(this IdentityBuilder builder, Uri endPoint, string authKey, string databaseName, string collectionName)
        {
            builder.Services.Add(IdentityDocumentDbServices.GetDefaultServices(endPoint, authKey, databaseName, collectionName));
            return builder;
        }
    }
}