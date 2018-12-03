--select maior monitoração

select count( (CONVERT(date,dataEstado, 0))) AS 'quantidade de estados', CONVERT(date,dataEstado, 0) as 'data' from dbo.historicoestadoprocessador
where FKCodComputador = 1003
group by (CONVERT(date,dataEstado, 0)) order by (CONVERT(date,dataEstado, 0)) 