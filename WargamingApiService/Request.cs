﻿/*
The MIT License (MIT)

Copyright (c) 2014 Iulian Grosu

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
 */
using System.IO;
using System.Net;

namespace WargamingApiService
{
  /// <summary>
  /// Wrapper over WebRequest in order to properly mock the object
  /// </summary>
  public class Request : IRequest
  {
    private readonly WebRequest _webrequest;

    /// <summary>
    /// We don't want a parameterless constructor
    /// </summary>
    private Request() { }

    public Request(string requestUri)
      : this()
    {
      _webrequest = WebRequest.Create(requestUri);
    }

    public string GetResponse()
    {
      var response = _webrequest.GetResponse();

      var responseStream = response.GetResponseStream();
      var output = string.Empty;

      if (responseStream != null)
        using (var reader = new StreamReader(responseStream))
          output = reader.ReadToEnd();

      response.Close();

      return output;
    }
  }
}
