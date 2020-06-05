-------------------------------------------------------
create procedure sp_businessInsert

@business_name varchar(40),
@turnover_amount decimal,
@tin int ,
@industry_type varchar(40),
@emp_number int,
@business_entity_type varchar(40),
@street_address varchar(50),
@city varchar(20),
@state varchar(20),
@zipcode int,
@business_dba varchar(40),
@date_of_establishment date,
@naics_code int,

@Query int

as
begin
if (@Query = 1)
begin
insert into BUSINESS (business_name, turnover_amount,TIN,industry_type,number_of_employees,business_entity_type,business_dba,date_of_establishment,naics_code)
values (@business_name,@turnover_amount ,@tin ,@industry_type, @emp_number,@business_entity_type,@business_dba,@date_of_establishment,@naics_code )

insert into BUSINESS_ADDRESS(street_address,city,state,zipcode)
values(@street_address,@city,@state,@zipcode)

if(@@ROWCOUNT >0)
begin
select 'Insert'
end
end
end

exec sp_businessInsert
@business_name='abc',
@turnover_amount=12.5 ,
@tin =12345,
@industry_type='automobile',
@emp_number=1000,
@business_entity_type='ssl',
@street_address='4th block Jayanagar',
@city='bangalore',
@state='karnataka',
@zipcode=564215,
@business_dba='tej company',
@date_of_establishment='22-02-2019',
@naics_code=123456,

@Query=1


select * from Business
select * from business_address