using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace codeTest.tretton37.poc.Models
{
    /// <summary>
    /// To create a common functionality which is used in accorss the solutions . 
    /// </summary>
    public class ModelService
    {
        public ArrayList GetListings()
        {
            ArrayList list = new ArrayList();
            string page = GetWebString(Constant.URL);
            MatchCollection listingMatches = Regex.Matches(page, Constant.RegularExpression_FindUrl);
            foreach (Match m in listingMatches)
            {
                Match _link = Regex.Match(m.Groups[0].Value, Constant.RegularExpression_FindUrlValue);
                list.Add(Constant.URL + _link.Groups[1].Value.ToString());
            }
            return list;
        }

        public string GetWebString(string url)
        {
            string appURL = url;
            HttpWebRequest wrWebRequest = WebRequest.Create(appURL) as HttpWebRequest;
            HttpWebResponse hwrWebResponse = (HttpWebResponse)wrWebRequest.GetResponse();
            StreamReader srResponseReader = new StreamReader(hwrWebResponse.GetResponseStream());
            string strResponseData = srResponseReader.ReadToEnd();
            srResponseReader.Close();
            return strResponseData;
        }

        public async Task SaveWebsourceAsync(ArrayList arrayList)
        {
            using (WebClient webClient = new WebClient())
            {
                for (int i = 0; i < arrayList.Count; i++)
                {
                    await Task.Run(() =>
                    {
                        try
                        {
                            webClient.DownloadFile(new Uri(arrayList[i].ToString()), Constant.FolderFileName + i.ToString());
                        }
                        catch (Exception ex)
                        { Console.WriteLine(ex.ToString()); }

                    });
                }

            }
        }
    }
}
