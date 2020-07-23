
Generate Issues:

Unity 2018.4 kept hanging when working with Visual Studio 2019.
This project uses Unity 2019.4

After loading Challenges 2 assets, the following error writes in the console:
	Library\PackageCache\com.unity.package-manager-ui@2.0.7\Editor\Sources\UI\PackageDetails.cs(622,17): error CS0246: The type or namespace name <...>
Fix is to open Window -> Package Manager and disable "Package Manager UI (2.0.7)".

GitHub doesn't handle Large File Storage (LFS) when downloading a project zip.
This results in incomplete art assets (models and textures).
To download the project as zip
	1. Click "Code" button.
	2. Right-click "Download ZIP" and choose "Save link as..."

