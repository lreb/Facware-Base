select * from public."Items" i order by i."Id"

insert into public."Items"
values('db',NOW() AT TIME ZONE 'UTC','lreb')


SELECT NOW() AT TIME ZONE 'UTC';

INSERT INTO public."Items"(
	"Name", "Created", "CreatedBy", "IsActive", "LastModified", "LastModifiedBy")
	VALUES ('demo', NOW() AT TIME ZONE 'UTC', 'lreb', True, NOW() AT TIME ZONE 'UTC', 'lreb');

INSERT INTO public."Items"(
	"Name", "Created", "CreatedBy", "IsActive")
	VALUES ('demo2', NOW() AT TIME ZONE 'UTC', 'lreb', True);