   M S B A M L   `   `   `  ����K  GAuthentification, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AuthentificationAuthentification  5   	   "    Authentification.login_user_   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Authentification     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  login_user_��5	   	   $	��506��6   $	��514��6*    � WindowStartupLocation$ CenterScreen=�66   
������� � AllowsTransparency .  � WindowStyle$
 None=�6�    � 
ResizeMode$ CanResizeWithGrip=�6�    � Icon$ img/LogoBlue.png��6�   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      $	��180 �6   6+   �� 5      6   .+�5   
   �� $��0��6   
������ ._�5      � .+�5      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryDark=�6+   .��5      �� $��Right=�6!   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowEdges$ Bottom=�6>   	   ShadowDepth$	 Depth4=�6o   .+�5      �� -   5        $��30��5   !   $��30��6,   $	 Depth3=�68   $��0q�6i   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]
   Kind$
 WindowClose=�66   5      5      5         5!      $ PrimaryDark=�6+   .��5"      �� $��Right=�6!    �� Orientation$ 
Horizontal=�6=   $ Bottom=�6V   $	 Depth4=�6�    J� RenderTransformOrigin$ 
-2.267,0.4&�6�   .+�5#      �� -   5        $��30��5#   !   $��30��6,   $	 Depth3=�68   $��0q�6i   $��0,0,10,0q�6�   .��5$        $
 WindowMinimize=�66   $��0,0,10,0q�6L   5%      �� 5&      -   5        $��30��5&   !   $��30��6-   $	 Depth3=�69   $��0q�6j   .��5'        $
 WindowClose=�66   5(      5*      5+      5-      5.      � 5/   
   $��1��6   .+�50        $ 
PrimaryMid=�6'   $	 Depth3=�69   $ Bottom=�6j   .��51      �� $��	Bienvenue��6   $��35(�6-   $��Center=�6;   $��	0 10 0 10q�6X   52      �� 53      $��Center=�6   .+�54      �� $��img/Sans titre-2.png��6   $	��180��62   $	��180��6>   $��0 60 0 0q�6K   $	 Depth3=�6]   �� 55      $
��LOGO��6   $��Center=�6$   $��Roboto)�6A   $��20(�6U   ���	#FF9C98986c   56      57      � 58   
   $��2��6   .+�59      �� $ Vertical=�6   .+�5;      �� $ 
Horizontal=�6   $��	60 10 0 0q�66   .+�5<        $
 Account=�6.   $��Bottom=�6y   $
��10 0q�6�   $��30��6�   $��30��6�   ��6>   ��  �� ElementName$
 user�� �� Path$ BorderBrush�6�   �� 5=      -   5         ��Name$
 user��5=      $	��300��6,   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ utilisateur��68      
IsFloating . ���	#89443C3C$��16(�6�   $��Roboto)�6�   5>      �� 5?      $ 
Horizontal=�6   $��60 10q�66   .+�5@        $	
 key=�6.   $��Bottom=�6t   $
��10 0q�6�   $��30��6�   $��30��6�   ��69   �� $
 pass��$ BorderBrush�6�   G� 5A      -   5         G�Name$
 pass��5A   "   $	��300��60   $ mot de passe��6=    . ���	#89443C3C$��16(�6�   $��Roboto)�6�   5B      �� 5D      -   5         ��Name$ valid��5D      $	��100��6(   $��	0 30 0 40q�64   $��	connexion��6G    $   MaterialDesignRaisedAccentButton#���   6o   ���	#FF1976D2$	 Depth2=�6�   ���	#DDFFFFFF��6�   Z� 6	  #  MaterialDesignThemes.Wpf.Card  5E      $��
10 0 10 10q�6&   $	��400��6:   $��Center=�6F   $��15q�6c   $	 Depth4=�6p   ���	#FFF3ECEC.��5F      �� $��Center=�6    �� 6?   -   5         �� TextDecorations 5F   I   Z� .�6w   mot de passe oublié ?6�   6�   5G      5H      5J      )  #MaterialDesignThemes.Wpf.DialogHost  5K   
   -   5          Name$ alert��5K   $      IsOpen .  $��3��6B      DialogContent 5L      �� 5N      $��15q�6   .+�5O      �� -	   5         ��Name$ 
alert_text��5O       $�� Bien connecté ��64   $��10q�6K   �� 5P      -
   5           CloseDialogCommand#��Z 5P       # MaterialDesignRaisedLightButton#���  6s   $
�� OK ��6�   ���	#FF2ECC716�   5Q      5T      5U      5Z      