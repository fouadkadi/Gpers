   M S B A M L   `   `   `  ����K  GAuthentification, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AuthentificationAuthentification  5   	   ,    &Authentification.Génération_document   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Authentification     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Génération_document��5	   	   $��429.921��6%   $	��800��66   .��5
      �  � RowDefinitions 5   
   �� 5      $��60 �6   6*   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   � $��0��6   $��2��6   .+�5      (  "MaterialDesignThemes.Wpf.ColorZone  -   5          Name$ colzone��5   (      Mode$ PrimaryDark=�69   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6L   .��5      �� .+�5      �� $��Center=�6    $��35(�6=   Géneration des documents6e   5      5      5      �� 5   
   $��1��6   $��	10 30 0 0q�6"   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��	30 10 0 0q�62   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�6*   $��Bottom=�6x   $
��10 0q�6�   $��30��6�   $��30��6�   ��6:   ��  �� ElementName$ employé��	 �� Path$	 BorderBrush�6�   �� 5      -   5        
 ��Name$
 employé��5      $	��200��6,   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ utilisateur��68      
IsFloating . ���	#89443C3C6�   5       �� 5!      -   5         ��Name$ valid��5!   A   $��
20 30 20 0q�6   .��5"      �� $ 
Horizontal=�6   $
��Left=�66   .+�5#        $ Check=�6.   $��Center=�6z   $��30��6�   $��30��6�   ��6<   �� $ employé��$	 BorderBrush�6�   �� 5$      $��5 0 0 0q�6    $��20(�61   $��Center=�6?   	Valider6e   5%      5&      5(      � 5*   
   $��1��6   $��1��6   .+�5+      #  MaterialDesignThemes.Wpf.Card  
�������$��0 0 20 0q�65   .��5,      �� .+�5-      9� -   5         9�Name$ droper��5/      
�������$��Stretch=�5.      $��Choix Du document ��50      .��51      �� .+�52      �� $ 
Horizontal=�6%   $��0 10 0 0q�6>   .+�53   "   �� -   5        $	 one��53   �   $��
20 0 10 0 q�6)   $
��Left=�6=   $��Center=�6X    &  "MaterialDesignFloatingActionButton#��[  6s   .��55   "     $
 Plus=�6:   $��30��6F   $��30��6R   6_   57      �� 58      $	��20 (�6(   $��Center=�67   $��30��6T   Attestation De travail6z   59      �� 5:      $ 
Horizontal=�6)   $��0 10 0 0q�6B   .+�5;   "   �� -   5        $	 two��5;   �   $��
20 0 10 0 q�6)   $
��Left=�6=   $��Center=�6X   #��[  6s   .��5=   &     $
 Plus=�6>   $��30��6J   $��30��6V   6c   5?   #   �� 5@   "   $	��20 (�6,   $��Center=�6;   $��30��6X   Certificat de travail6}   5A      �� 5B      $ 
Horizontal=�6)   $��0 10 0 0q�6B   .+�5C   "   �� -   5        $ three��5C   �   $��
20 0 10 0 q�6)   $
��Left=�6=   $��Center=�6X   #��[  6s   .��5E   &     $
 Plus=�6>   $��30��6J   $��30��6V   6c   5G   #   �� 5H   "   $	��20 (�6,   $��Center=�6;   $��30��6X   Titre de congé6v   5I      �� 5J      $ 
Horizontal=�6)   $��	0 10 0 10q�6B   .+�5K   "   �� -   5        $
 four��5K   �   $��
20 0 10 0 q�6)   $
��Left=�6=   $��Center=�6X   #��[  6s   .��5M   &     $
 Plus=�6>   $��30��6J   $��30��6V   6c   5O   #   �� 5P   "   $	��20 (�6,   $��Center=�6;   $��30��6X   Contrat de travail6z   5Q      5S      5T      5U      5V      5W      )  #MaterialDesignThemes.Wpf.DialogHost  5Y   
   -	   5          Name$ alert��5Y   $      IsOpen .  $��2��6B   $��2��6S      DialogContent 5Z      �� 5\      $��15q�6   .+�5]      �� -
   5         ��Name$ 
alert_text��5]       $�� Bien conneceté ��64   $��10q�6L   �� 5^         CloseDialogCommand#��Z 6    # MaterialDesignRaisedLightButton#���  6`   $
�� OK ��6�   ���	#FF2ECC716�   5_      5b      5c      5d      