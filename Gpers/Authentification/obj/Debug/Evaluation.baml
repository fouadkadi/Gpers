   M S B A M L   `   `   `  ����K  GAuthentification, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AuthentificationAuthentification  5   	   !    Authentification.Evaluation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Authentification     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � Title$ 
Evaluation��5   	   $��746.214��6   $��1202.912��6-   .��5      � -   5         �Name$
 grid��5      
�������.+�5   
   �� $
��1135��6   $
��Auto=�6$   ��. $��30,83,30,71q�6_   .��5      � -   5         �Name$ panel��5      $
��auto��6+   $
��1135��6:   5      (  "MaterialDesignThemes.Wpf.ColorZone  5   
   -   5          Name$ colzone��5   #      Mode$ 
PrimaryMid=�64   .��5      �� $��82��6   $
��1195��6!   .+�5      �� -   5         ��Name$ search��5       �� TextWrapping$
 Wrap=�6*   {�. )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$*	 $Saisissez un paramètre de recherche��5      
   HintOpacity$
 .8Q�6W   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowEdges$	 All=�6�      ShadowDepth$ Depth3=�6�   $��26��6�    �� Left$	 311��6�   
 �� Top$ 27��6�   $	��223��6  .��6  ��5      �� 5       �� Path$
 Name�5       �� UpdateSourceTrigger$ PropertyChanged=�5      5!      .��5"   $   5#      �� 5%      $	 135��6   $
��Wrap=�6.   $��15(�6B   $��Roboto)�6P   $ 32��6d   $��25��6t   $	��121��6�   �� 6�   $�Nom / Prenom :��6�   6�   �� 5&      -   5         ��Name$ filtre��5&   -   {�. $	 Search��5'       �� 
IsEditable . $
 1Q�5)   &   $��27��6P   $	 705��6\   $ 26��6n   $	��164��6~   �� 5*      -   5         ��Name$ filtret��5*      {�.  $
��Left=�6?   $
��Wrap=�6Z   $��15(�6n   $��Roboto)�6|   $��Poste :��6�   $	��Top=�6�   $��25��6�   $	 606��6�   $ 32��6�   �� 5+      -   5         ��Name$ 	recherche��5+   J   $ Depth2=�6   $��
Rechercher��6u   $
��Left=�6�    " MaterialDesignRaisedDarkButton#��[ 6�   $	��111��6�    � ToolTip$8 2Resource name: MaterialDesignRaisedLightDarkButton��5,      $
��Auto��6O   $	 990��6]   $ 28��6o   {�. 6   �� 5-      -   5        $ retour��5-      {�.  $
��Left=�6Q   $��0,0,0,0q�6l   $	��Top=�6~   $��35��6�   $0 *MaterialDesignFloatingActionMiniDarkButton��6�   $��35��6�    J� RenderTransformOrigin$ 1,0.87&�6�    * &MaterialDesignFloatingActionMiniButton#��[ 6  $ 31��6B  $ 22��6S  .��5.      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ ArrowLeftBold=�6.   $��35��6C   $��35��6O   $ 0.331,0.301&�6Z   5/      50      51      )  #MaterialDesignThemes.Wpf.DialogHost  52   
   -	   5          Name$ alert��52   4      IsOpen .     DialogContent 53      �� 54      $��15q�6   .+�55      �� $��Center=�6    $��10q�6=   Element Introuvable6^   �� 56      -
   5        $ 
nontrouvé��56   m   $��Ok��6      CloseDialogCommand#��Z 6*   6�   57      5:      5<      5=      