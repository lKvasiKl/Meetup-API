CREATE TABLE [dbo].[EventSpeaker]
(
	[EventId] INT
		CONSTRAINT [FK_EventSpeaker_Event] FOREIGN KEY
		REFERENCES [dbo].[Events]([Id]) ON DELETE NO ACTION,
    [SpeakerId] INT
		CONSTRAINT [FK_EventSpeaker_Speaker] FOREIGN KEY
		REFERENCES [dbo].[Speakers]([Id]) ON DELETE NO ACTION,
	CONSTRAINT [PK_EventSpeaker] PRIMARY KEY ([EventId],[SpeakerId])
)
GO

CREATE INDEX [IX_dbo_EventSpeaker_EventId] ON [dbo].[EventSpeaker]([EventId]);
GO

CREATE INDEX [IX_dbo_EventSpeaker_SpeakerId] ON [dbo].[EventSpeaker]([SpeakerId]);
GO