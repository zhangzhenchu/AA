use UFDATA_559_2017

if object_id('zhrs_t_zzcMaterialShortage') is not null
drop table zhrs_t_zzcMaterialShortage
go
create table zhrs_t_zzcMaterialShortage
(
MSId int identity(1,1)primary key,
MCoding varchar(50)not null,          --材料编码
MDate varchar(50) null,               --日期
MNumber varchar(100)null,             --数量
MExplain varchar(500)null,            --说明
MDescribe varchar(500)null,           --描述
MOther varchar(500)null               --其他 
)

select * from zhrs_t_zzcMaterialShortage

insert into zhrs_t_zzcMaterialShortage(MCoding,MDate,MNumber,MExplain,MDescribe,MOther)values('','','','','','')


select* from zhrs_t_zzcMaterialShortage
drop table zhrs_t_zzcMaterialShortage
delete from zhrs_t_zzcMaterialShortage where MCoding='15033014'
select Count(*) from zhrs_t_zzcMaterialShortage where MCoding = '16200442' and MDate='' and MNumber=''
select * from zhrs_t_zzcMaterialShortage where MCoding = '16400431'


