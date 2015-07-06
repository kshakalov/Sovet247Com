SELECT 
    [Extent1].[adminMessageId] AS [adminMessageId], 
    [Extent1].[parentMessageId] AS [parentMessageId], 
    [Extent1].[fromUserId] AS [fromUserId], 
    [Extent1].[toUserId] AS [toUserId], 
    [Extent1].[subject] AS [subject], 
    [Extent1].[message] AS [message], 
    [Extent1].[dateCreated] AS [dateCreated], 
    [Extent2].[adminMessageId] AS [adminMessageId1], 
    [Extent2].[parentMessageId] AS [parentMessageId1], 
    [Extent2].[fromUserId] AS [fromUserId1], 
    [Extent2].[toUserId] AS [toUserId1], 
    [Extent2].[subject] AS [subject1], 
    [Extent2].[message] AS [message1], 
    [Extent2].[dateCreated] AS [dateCreated1]
    FROM  [dbo].[AdminMessages] AS [Extent1]
    left JOIN [dbo].[AdminMessages] AS [Extent2] ON [Extent1].[parentMessageId] = [Extent2].[adminMessageId]
    WHERE (0 = [Extent1].[parentMessageId]) AND ([Extent1].[toUserId] in(0,21) OR [Extent1].[fromUserId] =21)