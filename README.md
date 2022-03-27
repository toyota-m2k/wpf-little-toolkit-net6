# wpf-little-toolkit (for .NET 6)

Some useful views, extensions and helper classes to develop WPF applications.
Someone (<- that's me) will be a little happier with this.

## CircleProgressView

  "Progress Ring" with a percent label, customizable from xaml.
  This implementation comes from [toyota-m2k/CircularProgressBar](https://github.com/toyota-m2k/CircularProgressBar).
  The implementaton for iOS is in it, and for Android is in [toyota-m2k/android-viewex](https://github.com/toyota-m2k/android-viewex).
 
## PathView

  The view drawing "SVG path" on it, similar to PathIcon in UWP.
  (Unfortunately, I couldn't found such control in WPF enviromnent.)
  
## StretchListView

  ListView which has a column to strech and fit to view width.

## NumericTextBox

  TextBox which accepts only numeric character.
 
## CheckButton

  A button which has IsChecked attribute.
  This is similar to ToggleButton, but it's IsChecked attribute will not be changed by click action but can be changed only programatically.
  It's useful in specal situation to handle "un-bindable property" of view for example "Play" property of MediaElement.
  
## MenuButton

  A button which is intended to bind its IsChecked property to DropDownMenu.IsOpen property.
  
## WaitCursor

  Disposable wait cursor class.
  A heavy task can be executed in it's "using block" like this.
  ```C#
  using(WaitCuror.Start(this)) {
    HeavyTask();
  }
  ```
 
 ## ViewModelBase
 
  A common implementation of ViewModel which support  INotifyPropertyChanged.
  This class is intended to work with [ReactiveProperty](https://github.com/runceel/ReactiveProperty), it can dispose automatically all properties  implement IDisposable.
  
 ## WinPlacement
 
  Save and Restore the placement (position, size) of the Window.
  
## RectUtil

  Utilities to handle Rect/Point/Size/Vector.
  
## JsonHelper

  Support composing and parsing JSON string.
  This is thin wrapper of System.Json, and enough to my use.
  
## FileDialogBuilder

  This is a wrapper of Microsoft.WindowsAPICodePack.Dialogs in a "builder" pattern.
  ```C#
  var path = SaveFileDialogBuilder.Create()
      .addFileType("Text", "*.txt")
      .defaultExtension("txt")
      .overwritePrompt(true)
      .defaultFilename("readme")
      .GetFilePath(this);
  ```
  
  # NuGet
  
    io.github.toyota32k.wpfLittleToolkit.net6
  
  # XAML
  
  ```XAML
  <Window ...
   xmlns:tk="clr-namespace:io.github.toyota32k.toolkit.view;assembly=io.github.toyota32k.wpfLittleToolkit.net6"
   ...>
   
   <tk:CircleProgressView.../>
  ```
  
  
  
