﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

/// <summary>
/// This class is responsible for handling REST API requests to remote server.
/// Clas này chịu trách nhiệm xử lý các yêu cầu để xử lý các requests REST API đến remote server (máy chủ từ xa)
/// To extend this class you just need to add new API methods.
/// Để mở rộng class này, bạn cần thêm mới API methods

/// </summary>
public class ServerCommunication : PersistentLazySingleton<ServerCommunication>
{
    #region [Server Communication]

    /// <summary>
    /// This method is used to begin sending request process.
    /// Phương thức này được sử dụng để bắt đầu gửi các yêu cầu
    /// </summary>
    /// <param name="url">API url.</param>
    /// <param name="callbackOnSuccess">Callback on success.</param>
    /// <param name="callbackOnFail">Callback on fail.</param>
    /// <typeparam name="T">Data Model Type.</typeparam>

    private void SendRequest<T>(string url, UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        StartCoroutine(RequestCoroutine(url, callbackOnSuccess, callbackOnFail));
    }

    /// <summary>
    /// Coroutine that handles communication with REST server.
    /// </summary>
    /// <returns>The coroutine.</returns>
    /// <param name="url">API url.</param>
    /// <param name="callbackOnSuccess">Callback on success.</param>
    /// <param name="callbackOnFail">Callback on fail.</param>
    /// <typeparam name="T">Data Model Type.</typeparam>
    private IEnumerator RequestCoroutine<T>(string url, UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        var www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
            callbackOnFail?.Invoke(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            ParseResponse(www.downloadHandler.text, callbackOnSuccess, callbackOnFail);
        }
    }

    /// <summary>
    /// This method finishes request process as we have received answer from server.
    /// </summary>
    /// <param name="data">Data received from server in JSON format.</param>
    /// <param name="callbackOnSuccess">Callback on success.</param>
    /// <param name="callbackOnFail">Callback on fail.</param>
    /// <typeparam name="T">Data Model Type.</typeparam>
    private void ParseResponse<T>(string data, UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        var parsedData = JsonUtility.FromJson<T>(data);
        callbackOnSuccess?.Invoke(parsedData);
    }

    #endregion

    #region [API]

    /// <summary>
    /// This method call server API to get a quote.
    /// </summary>
    /// <param name="callbackOnSuccess">Callback on success.</param>
    /// <param name="callbackOnFail">Callback on fail.</param>
    public void GetQuote(UnityAction<QuoteData> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        SendRequest(string.Format(ServerConfig.SERVER_API_URL_FORMAT, ServerConfig.API_GET_QUOTE), callbackOnSuccess, callbackOnFail);
    }

    /// <summary>
    /// This method call server API to get an info about my blog.
    /// </summary>
    /// <param name="callbackOnSuccess">Callback on success.</param>
    /// <param name="callbackOnFail">Callback on fail.</param>
    public void GetBlogInfo(UnityAction<BlogInfoData> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        SendRequest(string.Format(ServerConfig.SERVER_API_URL_FORMAT, ServerConfig.API_GET_BLOG_INFO), callbackOnSuccess, callbackOnFail);
    }

    #endregion
}

