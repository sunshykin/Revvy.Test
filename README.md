# Revvy.Test

Решение задачи для Revvy.

## Описание


    Есть N чиновников, каждый из которых выдает справку определенного вида.
    Кроме того, у каждого чиновника есть набор справок, которые нужно получить до того,
    как обратиться к нему за справкой.
  
  Задача - создать алгоритм, по которому можно получить все справки и обойтись без рекурсии.
  
  
 ### Пример
 N = 4.
 Зависимость между чиновниками - `{1, [2]}, {2, [3, 4]}` (т.е. для получения справки от
 первого чиновника - требуется справка от второго. А для справки от второго - справки от 3 и 4).
 
 Допустимые ответы:
 
 * {3, 4, 2, 1}
 * {4, 3, 2, 1}
