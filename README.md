# ambrosial
> A launcher made for MC:BE mods
> 
Ambrosial is a launcher for Minecraft: Bedrock Edition (specifically Windows 10 Edition) modifications. The source code is here for you to check for any malicious code, or if you're just curious.

## How it works
Ambrosial sends a download request to the server to download a encrypted JSON file (can be generated using the developer form) and then decrypts it and adds the modification's buttons and such to a windows form, then attaches events to the buttons. You can see how this works in more detail in the source code.

## Final notes
Ambrosial uses a NuGet plugin called Fody to merge all the extra libaries into the main executable, you may need to install the package after downloading the source.
