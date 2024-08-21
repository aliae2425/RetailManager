CREATE PROCEDURE [dbo].[spUserLookup]
	@Id NVARCHAR(128)
AS
begin
	Set nocount on;

	SELECT Nom, Prenom, Email, CreateDate
	from [dbo].[User]
	WHERE Id = @Id;
end