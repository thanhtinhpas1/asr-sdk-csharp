# ASR VietSpeech .NET Standard SDK

The .NET Standard SDK uses [ASR VietSpeech][wdc] services, a collection of REST APIs that use recognize speech to text.

## Table of Contents
* [Before you begin](#before-you-begin)
* [Installing the ASR .NET Standard SDK](#installing-the-watson-net-standard-sdk)
* [.NET Standard 4.1](#net-standard-20)

## Before you begin
Ensure you have the following prerequisites:

* You need an [ASR VISPEECH][asr-service] account.
* Install [Visual Studio][visual-studio-download] for Windows, OSX or Linux.
* Install [.NET Core][dotnet-core-download].

## Installing the ASR .NET Standard SDK
This SDK provides classes and methods to access the following Watson services:

You can get the latest SDK packages through [NuGet](https://www.nuget.org).

[NuGet]: https://www.nuget.org/packages/asr-vietspeech/

## .NET Standard 4.1
The ASR .NET Standard SDK conforms to .NET Standard 4.1. It is implemented by .NET Core 4.1, .NET Framework 4.6.1 and Mono 5.4. See [Microsoft documentation](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) for details.

### IAM

Some services use token-based Identity and Access Management (IAM) authentication. IAM authentication uses a service API key to get an access token that is passed with the call. 

You supply either an IAM service **API key** or an **access token**:

- Use the API key to have the SDK manage the lifecycle of the access token. The SDK requests an access token, ensures that the access token is valid, and refreshes it if necessary.
- Use the access token if you want to manage the lifecycle yourself. 
stance gives you.