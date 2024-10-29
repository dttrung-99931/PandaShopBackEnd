using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;

namespace PandaShoppingAPI.Utils
{
	public class APIPaths
	{
        public const string singalR = "/SignalR";

        public class Orders
        {
            public const string endpoint = "/v1/Orders";
            public const string startProcessing = $"{endpoint}/{{id}}/StartProcessing";
            public const string completeProcessing = $"{endpoint}/{{id}}/CompleteProcessing";
            public const string getCompleteProcessingOrders = $"{endpoint}/CompleteProcessing";
            public const string requestPartnerDelivery = $"{endpoint}/RequestPartnerDelivery";
            public static List<string> processingPaths = new List<string>() {
                startProcessing,
                completeProcessing
            };

            public static bool isOrderProcessingPath(string path, out int orderId)
            {
                foreach (string processingPath in processingPaths)
                {
                    var routeDic = new RouteValueDictionary();
                    TemplateMatcher matcher = new TemplateMatcher(
                       TemplateParser.Parse(processingPath),
                       new RouteValueDictionary()
                   );

                    if (matcher.TryMatch(path, routeDic))
                    {
                        orderId = int.Parse(routeDic["id"].ToString());
                        return true;
                    }
                }

                orderId = Constants.EMPTY_ID;
                return true;
            }

        }

    }
}

