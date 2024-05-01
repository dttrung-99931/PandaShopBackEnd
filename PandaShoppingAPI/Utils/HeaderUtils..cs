using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PandaShoppingAPI.Utils
{
    public class HeaderUtils
    {
        static public void SetCreatedIdsToHeader(Microsoft.AspNetCore.Http.IHeaderDictionary headers, IEnumerable<int> createdIds)
        {
            // Wirte createdId to response header that will be used in NotificationMiddleware 
            string createdIdStr =  string.Join(',', createdIds);
            headers.Add(Constants.Headers.createdIds, createdIdStr);
        }

        static public List<int> GetCreatedIdsFromHeader(Microsoft.AspNetCore.Http.IHeaderDictionary headers)
        {
            string idsStr = headers[Constants.Headers.createdIds];
            if (!string.IsNullOrEmpty(idsStr)){
                return idsStr.Split(',').Select((idStr) => int.Parse(idStr)).ToList();
            }
            return new List<int>();
        }


    }
}
