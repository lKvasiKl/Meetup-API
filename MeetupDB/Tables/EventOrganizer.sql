CREATE TABLE [dbo].[EventOrganizer]
(
	[EventId] INT
		CONSTRAINT [FK-EventOrganizer_Event] FOREIGN KEY
		REFERENCES [dbo].[Events]([Id]) ON DELETE NO ACTION,
    [OrganizerId] INT
		CONSTRAINT [FK-EventOrganizer_Organizer] FOREIGN KEY
		REFERENCES [dbo].[Organizers]([Id]) ON DELETE NO ACTION,
	CONSTRAINT [PK_EventOrganizer] PRIMARY KEY ([EventId], [OrganizerId])
)
GO

CREATE INDEX [IX_dbo_EventOrganizer_EventId] ON [dbo].[EventOrganizer]([EventId]);
GO

CREATE INDEX [IX_dbo_EventOrganizer_OrganizerId] ON [dbo].[EventOrganizer]([OrganizerId]);
GO