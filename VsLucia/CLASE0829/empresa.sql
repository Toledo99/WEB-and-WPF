--1.	Mostrar los nombres de los empleados ordenados alfabéticamente en orden descendiente (z..a)
select nombre from empleado$ order by nombre desc

--2.	Listar los nombres de los empleados cuyo nombre termine con la letra "o"
select nombre from empleado$  where right (nombre,1)='o'
select nombre from empleado$  where nombre like '%o'

--3.	Seleccionar el nombre, el oficio y salario de los empleados que trabajan en León.
select nombre, oficio, salario from empleado$ where dir='Leon'

--4.	Nombre de los empleados que trabajan en León y cuyo oficio sea analista o empleado 
select nombre from empleado$ where dir='Leon' and oficio in ('vendedor','empleado')
select nombre from empleado$ where dir='Leon' and (oficio='vendedor' or oficio='empleado')

 --5.	Calcular el salario medio de todos los empleados
 select avg(salario) as promedio from empleado$ 

 --6.	¿cuál es el máximo salario de los empleados del departamento 10?
 select max(salario) as max from empleado$ where deptoNo=10

 --7.	Calcula el número de empleados que no tienen comisión
 select count(comision) as sinComision from empleado$ where comision=0

 --8.	Mostrar cuántos nombres de los empleados empiezan con la letra A
 select count(*) as nombresA from empleado$ where nombre like 'V%'

 --9.	¿Cuántos empleados hay en el departamento número 10?
 select count(*) from empleado$ where deptoNo=10

 --10.	Para cada oficio obtener la suma de salarios
 select oficio, sum(salario) from empleado$ group by oficio 

 --11.	Seleccionar el nombre, el oficio y la localidad de los departamentos donde trabajan los vendedores
 select empleado$.nombre, empleado$.oficio, departamento$.localizacion from empleado$,departamento$
 where empleado$.deptoNo=departamento$.deptoNo and oficio='vendedor' 
 --^ Se necesitan igualar las claves unicas despues del where cuando haya más de una tabla 

 --12.	Seleccionar el nombre, salario y localidad donde trabaja los empleados que tengan un salario entre 10,000 y 13,000
 select empleado$.nombre, empleado$.salario, departamento$.localizacion from empleado$,departamento$ where empleado$.deptoNo=departamento$.deptoNo
 and empleado$.salario between 10000 and 13000
 
  --13.	Mostrar los datos de los empleados que trabajan en el departamento de contabilidad, ordenados por nombre
  select * from empleado$,departamento$ where empleado$.deptoNo=departamento$.deptoNo and departamento$.nombreDepto='Contabilidad'
  order by nombre asc

  --14.	Calcula el salario mínimo de los empleados del departamento de ventas
  select min(empleado$.salario) as salMinVentas from empleado$, departamento$ where empleado$.deptoNo=departamento$.deptoNo and
   departamento$.nombreDepto='Ventas'

   --15.	Calcula el promedio del salario de los empleados del departamento de contabilidad
   select avg(empleado$.salario) as promSalCont from empleado$,departamento$ where empleado$.deptoNo=departamento$.deptoNo and
   departamento$.nombreDepto='Contabilidad'