Issues:
Unity 2018.4 kept hanging when working with Visual Studio 2019.
Instead usign Unity 2019.4

However after loading the Challenges 2 assets I got the following error to the console:
	Library\PackageCache\com.unity.package-manager-ui@2.0.7\Editor\Sources\UI\PackageDetails.cs(622,17): error CS0246: The type or namespace name 'VisualElement' could not be found (are you missing a using directive or an assembly reference?)

Fix is to open Window -> Package Manager and disable "Package Manager UI (2.0.7)".

