   M S B A M L   `   `   `  ����C  ?todolist, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:todolisttodolist  5   	       todolist.ListWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:todolist     5   	     � Title$  To-Do Lists��5   	   $	��450��6   $	��800��6*   .��5	      � .+�5
   
   �� -   5         ��Name$ 
lblWelcome��5
      $��Label��6$   $
��Left=�64   $��
617,10,0,0q�6O   $	��Top=�6c   $	��167��6{   �� 5   
   -   5        $��lstToDo��5   *   $��10,10,214,153q�6    �� View 5      �� 5      .P�5      �� $
��Name��6%    �� Width$	 140��63    �� DisplayMemberBinding 6?   �� *Name+6g   �� 5      $��Create Date��6%   $	 215��6:    6F   �� *
CreateDate+6t   �� 5      $��Update Date��6%   $	 215��6:    6F   �� *
UpdateDate+6t   5      5      �� 5   
   -   5         ��Name$ 
btnAddToDo��5      $��	Add To-Do��6%   $
��Left=�69   $��
44,302,0,0q�6T   $	��Top=�6h   $	��135��6�   $��34��6�   6�   �� 5   
   -   5        $ btnDeleteToDo��5      $��Delete To-Do(s)��6(   $
��Left=�6B   $��216,302,0,0q�6]   $	��Top=�6r   $	��135��6�   $��34��6�   6�   �� 5   
   -   5         ��Name$ 	spAddToDo��5      $��248,61,283,188q�6(   $	��172��6@   ���#CCCCCC.+�5      �� .��6   
To-Do Name6    �� 5      -   5         ��Name$ txtToDoName��5      $��
25,0,62,20q�6+   $��32��6?   �� 5      -   5        $ btnCreateToDo��5      $��29��6,   $��
31,0,77,20q�68   $��Create��6L   6]   �� 5      -   5        $ btnClose��5      $��29��6'   $��	31,0,77,0q�63   $��Close��6F   6V   5      �� 5    
   -	   5        $ btnShowTasks��5       $��Show Task(s)��6'   $
��Left=�6>   $��394,302,0,0q�6Y   $	��Top=�6n   $	��135��6�   $��34��6�   6�   5!      5"      