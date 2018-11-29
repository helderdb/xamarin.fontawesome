# xamarin.fontawesome
With **xamarin.fontawesome** you can use the popular icon library FontAwesome 5.2.0 within your Xamarin Forms applications. Android and iOS supported

## Installation
You can download source and build project on your own or install package via nuget

```PowerShell
PM> Install-Package xamarin.fontawesome
```

### iOS Installation

Add the Font Awesome font files to your Resources folder in your project and add them in your Info.plist file.

For more details on how to include custom fonts in iOS: [Click here](https://blog.xamarin.com/custom-fonts-in-ios/)

## Usage

First define namespace in your xaml file:

```xaml

<ContentPage 
  x:Class="My.Awesome.Page"
  xmlns="http://xamarin.com/schemas/2014/forms"
  xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
  xmlns:fa="clr-namespace:Xamarin.Forms.FontAwesome.Controls;assembly=Xamarin.Forms.FontAwesome">

  ...
  
</ContentPage>

```

After that you can use the **fa:Icon** control to display awesome icons. Property **FaName** specifies the icon name to display. If an icon has more then one style you can switch it with property **FaStyle** between **Brands**, **Regular** und **Solid**. The **fa:Icon** control size can be changed wirh **FontSize** property. The color can be changed with **FontColor** property.

```xaml

 ...
 
  <Grid>
    
  <fa:Icon
    FaName="bars"
    FaStyle="Solid"
    FontSize="26"
    HorizontalOptions="Start"
    TextColor="#00FF00" />
  
  </Grid>
 
 ...

```
