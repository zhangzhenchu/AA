use UFDATA_559_2017

if object_id('zhrs_t_zzcMaterialShortage') is not null
drop table zhrs_t_zzcMaterialShortage
go
create table zhrs_t_zzcMaterialShortage
(
MSId int identity(1,1)primary key,
MCoding varchar(50)not null,          --���ϱ���
MDate varchar(50) null,               --����
MNumber varchar(100)null,             --����
MExplain varchar(500)null,            --˵��
MDescribe varchar(500)null,           --����
MOther varchar(500)null               --���� 
)

select * from zhrs_t_zzcMaterialShortage

insert into zhrs_t_zzcMaterialShortage(MCoding,MDate,MNumber,MExplain,MDescribe,MOther)values('','','','','','')


select* from zhrs_t_zzcMaterialShortage
drop table zhrs_t_zzcMaterialShortage
delete from zhrs_t_zzcMaterialShortage where MCoding='15033014'
select Count(*) from zhrs_t_zzcMaterialShortage where MCoding = '16200442' and MDate='' and MNumber=''
select * from zhrs_t_zzcMaterialShortage where MCoding = '16400431'


