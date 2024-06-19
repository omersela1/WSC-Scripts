using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Result
{
    public string player;
    public float time;
    public int steps;

    public Result(string user, float time, int steps)
    {
        this.player = user;
        this.time = time;
        this.steps = steps;
    }
}

public class HTTPHandler : MonoBehaviour
{
    private HttpClient client = new HttpClient();

    public async Task<string> PostJsonDataAsync(string url, Result data)
    {
        try
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            ;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                Debug.LogError($"Error: {response.StatusCode}, {response.ReasonPhrase}");
                string responseBody = await response.Content.ReadAsStringAsync();
                Debug.LogError($"Response Body: {responseBody}");
                return null;
            }
        }
        
        catch(Exception e)
        {
            Debug.Log($"Could not post result to database: {e.ToString()}");
            return null;
        }
    }

    public async Task<List<Result>> GetTopResultsAsync(string url)
    {
        try
        {
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<List<Result>>(responseBody);
                return results;
            }
            else
            {
                Debug.LogError($"Error: {response.StatusCode}, {response.ReasonPhrase}");
                string responseBody = await response.Content.ReadAsStringAsync();
                Debug.LogError($"Response Body: {responseBody}");
                return null;
            }
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request error: {e.Message}");
            return null;
        }
        catch (TaskCanceledException e)
        {
            Debug.LogError($"Request timeout: {e.Message}");
            return null;
        }
        catch (Exception e)
        {
            Debug.LogError($"Unexpected error: {e.Message}");
            return null;
        }
    }
    
}


    