   M S B A M L   `   `   `  ����K  GAuthentification, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AuthentificationAuthentification  5   	   %    Authentification.modif_password   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Authentification     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��360��5
   
   $	��491��6     � WindowStartupLocation$  CenterScreen=�6#    � Icon$ img/iconmini.png��6H   .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $	��180 �6   6+   �� 5      6   .+�5   
   � $��0��6   .+�5      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryDark=�6'   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6:   .��5      �� $��Center=�6   $��Center=�6:   .+�5      �� $��	0 10 0 10q�6    $��35(�63   $��Roboto Light)�6A   Modifier le mot de passe6v   5      5      5      � 5   
   $��1��6   .+�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��	60 10 0 0q�66   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�6.   {�.  $��Bottom=�6�   $
��10 0q�6�   $��30��6�   $��30��6�   ��6P   ��  �� ElementName$
 user�� �� Path$ BorderBrush�6�   �� 5      -   5        	 ��Name$
	 user��5      $	��300��6,   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 utilisateur��68      
IsFloating . ���	#89443C3C$��16(�6�   $��Roboto)�6�   5      �� 5      $ 
Horizontal=�6   $��60 10q�66   .+�5         $	 key=�6.   $��Bottom=�6t   $
��10 0q�6�   $��30��6�   $��30��6�   ��69   �� $
 user��$ BorderBrush�6�   G� 5!      -   5         G�Name$ passwordBox_old��5!   "   $	��300��6;   $
 ancien mot de passe��6H    . ���	#89443C3C$��16(�6�   $��Roboto)�6�   5"      �� 5#      $ 
Horizontal=�6   $��60 10q�66   .+�5$        $	 key=�6.   $��Bottom=�6t   $
��10 0q�6�   $��30��6�   $��30��6�   ��69   �� $
 user��$ BorderBrush�6�   G� 5%      -   5        $ passwordBox_new��5%   "   $	��300��6;   $
 nouveau mot de passe��6H    . ���	#89443C3C$��16(�6�   $��Roboto)�6�   5&      5(      5*      � 5+   
   $��2��6   .+�5,      �� -   5         ��Name$ Ajout��5,      $��Valider��6$   $��Center=�66   $��28��6S   $��Center=�6`   $	��103��6{    "  MaterialDesignRaisedDarkButton#���   6�   6�   5.      )  #MaterialDesignThemes.Wpf.DialogHost  5/   
   -   5          Name$ alert��5/   $      IsOpen .  $��3��6B      DialogContent 50      �� 52      $��15q�6   .+�53      �� -   5         ��Name$ 
alert_text��53       $�� Bien conneceté ��64   $��10q�6L   �� 54         CloseDialogCommand#��Z 6    # MaterialDesignRaisedLightButton#���  6`   $
�� OK ��6�   ���	#FF2ECC716�   55      58      59      5:      