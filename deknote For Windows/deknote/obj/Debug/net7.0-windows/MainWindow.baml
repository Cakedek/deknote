   M S B A M L   `   `   `  ????B  >deknote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:deknotedeknote  5   	       deknote.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:deknote     5   	     ? WindowStartupLocation$  CenterScreen=?5   	    ? Title$ deknote??5	   	   $	??450??6   $	??800??6&   .??5
      ? .+?5   
   ?? -   5         ??Name$ bananalistbox??5         PromptMediumFontFamily#??[  6)   $
??Left=?6^   $	??243??6y   $??0,0,0,28q?6?   ?? 5   
   $
??Left=?6   
???   ?$	??243??6>   ?? 5   
   -   5         ??Name$ 	cake_open??5      $
??Open??6$   #???   63   $
??Left=?6i   $??Bottom=?6?   $??28??6?   $	??243??6?   6?   ?? 5   
   $??	243,0,0,0q?6   ???	#FFF1F1F16'   ?? 5   
   -   5         ??Name$ 
cake_title??5      $??42??6&   $??
260,25,0,0q?62   $	??Top=?6F   $??30(?6u   $??select item??6?   $??Prompt)?6?   ??6^   Z? ??6?   Z? 6?   c? 5   
   $??25??6   $	??Top=?6   $??	243,0,0,0q?66   $??Prompt)?6I   .@?5      ?? -   5        $ 
cake_open1??5      $
??Open??6)   68   ?? 5      -   5        $ cakesave_button??5      $
??Save??6.   6=   ?? 5      -   5        $ welcome??5      $??Welcome??6&   68   ?? 5      -   5        $ preference_button??5      $??
Preference??60   6E   5      ?? 5   
   $??0??6   $??
250,86,8,0q?6    ?? CornerRadius$ 10, 10, 0, 0??62   $??1q?6N   ???	#FFA5A5A5
??????? J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q?6#      
BlurRadius$ 10Q?61   	   Opacity$		 0.4Q?6A   
   ShadowDepth$
 0Q?6O   ._?5      ?? -   5         ??Name$ cake_sub??5      $??9,9,15,0q?6-   $??15(?6m   $??Prompt)?6?   ??6@   Z? ??6W   Z?  ?? SelectionTextBrush 6{   Z? . ?5      /? .T?5      J? .*?6    .*?5       ?? $?select item??6   5!      5"      5#      5$      ?? 5%   
   $
??Left=?6   $??19??6/   $??
260,67,0,0q?6;   $
??Wrap=?6O   $
??Date??6c   $	??Top=?6o   $??32??6?   ?? 5&   
   -	   5         ??Name$ sub_date??5&      $
??Left=?6&   $??19??6A   $??
297,67,0,0q?6M   $
??Wrap=?6a   $??
DD-MM-YYYY??6u   $	??Top=?6?   $	??163??6?   5'      5(      