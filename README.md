LawPanel
======

This project contains a Portable Class Library containing a typed .NET client gateway for accessing [LawPanel's Firms REST API](https://developer.lawpanel.com/docs/services/).


## Features

  - **Small**, typed, message-based API uses only clean DTO's
  - **Portable** profile available supporting .NET 4.5, ASP.NET Core 1.0, Windows 8, Xamarin.Android, Xamarin.iOS clients 
  
## Install LawPanel.ApiClient.DotNet

Install from NuGet with:

    PM> Install-Package LawPanel.ApiClient.DotNet

Includes Portable Version (.NET 4.5, ASP.NET Core 1.0, Windows 8, Xamarin.Android, Xamarin.iOS) 

## Usage

Requires a [registered LawPanel API Key](https://developer.lawpanel.com/docs/services/), e.g:

```csharp
var lawpanel = new LawPanelClient("8a5536dc-6d34-4f4a-8cac-a67201481ca0");
```

Some API methods requires, in addition to the API Key, the authentication at level user.

So, you can call the constructor as below:

```csharp
var lawpanel = new LawPanelClient("8a5536dc-6d34-4f4a-8cac-a67201481ca0","user@domain.ext","password");
```

Request and return DTO's are just clean POCO's, e.g:

```csharp
public class SearchDto : Dto, IIdentifiableDto
{
  public string               Id          { get; set; }
  public string               SearchTerm  { get; set; }
  public string               Classes     { get; set; }
  public DateTime             StartTime   { get; set; }
  public DateTime             EndTime     { get; set; }
  public int                  Score       { get; set; }
  public string               Weightings  { get; set; }
  public SearchType           Type        { get; set; }
  public TrademarkRegistry    Registry    { get; set; }
  public SearchStatus         Status      { get; set; }
  public string               StatusText  { get; set; }
}
```
## Documentation

These API examples follows [LawPanel's Firm API Documentation](https://developer.lawpanel.com/docs/services/57d1b3e7781258070026484d).

## [Searches](https://developer.lawpanel.com/docs/services/57d1b3e7781258070026484d/operations/57d1b3e978125813d06c1c0c)

### Creating a new trademark search 

```csharp
var searchDto = lawpanel.CreateSearch(new SearchQuery
{
    Classes = "3,25,15",
    Registry = "UK",
    ClassType = "SelectedClassesAndRelatedClasses",
    Type = "1",
    Weighting = "0,1",
    SearchTerm = "the lawpanel",
    SearchOriginId = "7C723DAA-9D75-433D-848D-A673000391DA"
});
```
### Retrieving a Search status


```csharp
var searchStatusDto = lawpanel.GetStatus(searchDto.Id);
```