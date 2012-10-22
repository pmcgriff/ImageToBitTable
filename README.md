Defeat Email Image Blocking
===========================

Ever get annoyed when your well-crafted emails look crappy because the email client has blocked images?

I know.

Build this code and run the app.

Enter the URL of your image(s) and choose your pixel size.

This app will create a bitmap, so to speak, using table cells with bgcolors to pixelize your image.
It won't be great, but it will be much better than the default broken image icon.

![Image Rendered with Table Cells](https://github.com/pmn4/ImageToBitTable/blob/master/gist/bittable-step1.png?raw=true "Image Rendered with Table Cells")

THEN, when your users allow images, they will see the actual image displayed right over top of the pixelated version.


### How's that?

The markup contains a 0-width div with `overflow:visible;`.
Within that div is a table, whose dimensions are the size of your image.
Within that table is a single cell, whose `background` attribute set to the URL of your image.

That's it.

Huge tip of the cap to Email on Acid for the idea (http://www.emailonacid.com/email-preview/mozify) and a project called GetPixelAtPoint which was a nice starting point that I just sort of found online.
