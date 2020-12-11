#XAML
- XAML is basically XML
- using XAML for implementing MVVM
``` C#
namespace XamarinApp
{
    public partial class NotesPage : ContentPage
    {
```
``` XML
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="XamarinApp.NotesPage"
             Title="Notes">
```
- When Visual Studio builds the project, it parses the XAML file to generate a C# code file. look into \obj\Debug directory
- At runtime, code in the particular platform project calls a LoadApplication method and then InitializeComponent calls the LoadFromXaml method that extracts the XAML file 
# Android Emulator networking
https://developer.android.com/studio/run/emulator-networking
10.0.2.2	Special alias to your host loopback interface (i.e., 127.0.0.1 on your development machine)
127.0.0.1	The emulated device loopback interface
# Pages
https://www.codemag.com/article/1507101/Xamarin-Pages-The-Screens-of-an-App
- ContentPage: A simple page that displays a single view, often used as a child page in other page types
  - The basic structure is 
``` XML
<ContentPage>
    <ContentPage.Content>
        <StackLayout>
            <Label/>
            <Label/>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```
- MasterDetailPage: A divided page that show two pane
- TabbedPage: Container for child pages. Switch between pages using a tabbed interface
- CarouselPage: Container for child pages. Switch between pages using a swipe gesture
- NavigationPage: Provides a service that supplies a back stack and allows navigation to pages within the app

# Resource Directory
You can define resources on Application or Page level

# Environment
folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

# Where is /dat/data/MyApp
https://forums.xamarin.com/discussion/34232/where-is-dat-data-myapp-directory-on-hard-drive
The Android emulator is a Virtual Machine running the Android operating system.
Use the Android Device Monitor (aka DDMS) to browse through your emulator's file system. The easiest way to do this is to:

* Start your Emulator and make sure it's running.
* Open up Visual Studio (if it's not open already).
* Go to "Tools->Android->Android Device Monitor".