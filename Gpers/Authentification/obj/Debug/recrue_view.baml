   M S B A M L   `   `   `  ����K  GAuthentification, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AuthentificationAuthentification  5   	   E ADragablz, Version=0.0.3.203, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz 5   	   "    Authentification.recrue_view   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Authentification     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   7dragablz(clr-namespace:Dragablz;assembly=Dragablz  5   	     � Title$  recrue_view��5   	   $	��550��6   $	��420��6*    � WindowStyle$
 None=�66    � WindowStartupLocation$ CenterScreen=�6I    � 
ResizeMode$ NoResize=�6n   .��5      � 
�������$	��550��6   $	��420��6+    � ColumnDefinitions 5   
   �� 5      .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  -   5          Name$ colzone��5   #   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�64   .��5      �� $ Depth3=�6   .+�5      �� $��35(�6   $��Center=�6*   $��10q�6G   
Formulaire5      5      5      � 5   
   $��0,57,0,0q�5      
������� � 	Resources 5       �� 
TargetType   MaterialDesignCheckBox	 �� BasedOn
 �� Property �� Value  MaterialDesignTextBox)  #MaterialDesignThemes.Wpf.HintAssist��%  '��       7   '�� [     7  �� 5      " ��5      8	   .�5      �� 
 � ��$ 8,8,10,8q�5       5!      �� 5"      " ��5#      8	   .�5%      �� 
 �@ 
IsFloating . 5'      �� 5(      
 � ��$ 8,8,8,8q�5*      5+      5,       5-      �� 5.      $��* �5/      �� 50      $
��Auto �51       � RowDefinitions 53      �� 54      $
��auto �55      �� 56      $
��auto �57      �� 58      $
��auto �59      �� 5:      $
��auto �5;      �� 5<      $
��auto �5=      .+�5@      �� -   5         ��Name$	 nom��5D   
   $��0��5A   	   $��0��5B   	      Hint$ Nom et Prénom��5C   	   ���	#89443C3C$	��400��5D   /   $
��Left=�6;   $��	8,16,8,16q�6V   �� 5E      -   5        $	 num��5J   
   $��0��5F   	   $��1��5G   	    �� 	MaxLength$ 10��5H      $ Numéro de Téléphone��5I   	   ���	#89443C3C$	��400��5J   /   $
��Left=�6;   $��	8,16,8,16q�6V   6i   �� 5K      -   5        $	 adr��5O   
   $��0��5L   	   $��2��5M   	   $ Adresse mail��5N   	   ���	#89443C3C$	��400��5O   /   $��	8,16,8,16q�6=   $
��Left=�5P   	   �� 5Q      -   5        $ poste��5Q      $ Poste��6%   $��0��6L   $��3��6\   ���	#89443C3C$	��400��6�   $
��Left=�6�   $��	8,16,8,16q�6�   �� 5S      -   5         ��Name$ button_Copy��5S      $��50��6+   $	��140��68   $��Right=�6D   $��0,33,130,-77q�6`   $��4��6�   .��5T      �� $��50��6   $	��170��6*   .+�5U      �� $��0,5,98,0q�6   $��Ajouter��6.   $��39��6@   '  !MaterialDesignThemes.Wpf.PackIcon  5V      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�6.   $��41��6:   $��31��6F   $��
0,-45,60,0q�6Q   $��Right=�6e   $��Center=�6�   5W      5X      5\      �� 5^   
   -   5        $��40��5^      $��40��6   $��Right=�6*   $	��Top=�6F   $��0q�6^   $ Depth0=�6r   
������ $��	0,10,10,0q�6�   .��5_        $ Close=�6&   $��30��63   $��40��6?   $��Center=�6K   $��Center=�6h   5`      )  #MaterialDesignThemes.Wpf.DialogHost  5a   
   -   5          Name$ alert��5a   $      IsOpen .  $��	0,0,0,-13q�6B      DialogContent 5b      �� 5d      $��15q�6   .+�5e      �� -	   5         ��Name$ 
alert_text��5e       $�� Bien conneceté ��64   $��10q�6L   �� 5f         CloseDialogCommand#��Z 6    # MaterialDesignRaisedLightButton#���  6`   $
�� OK ��6�   ���	#FF2ECC716�   5g      5j      5k      5m      