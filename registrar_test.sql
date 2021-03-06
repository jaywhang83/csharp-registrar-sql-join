CREATE DATABASE registrar_test;
GO
USE [registrar_test]
GO
/****** Object:  Table [dbo].[courses]    Script Date: 3/9/2016 4:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[course_number] [varchar](255) NULL,
	[department_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[departments]    Script Date: 3/9/2016 4:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[departments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[students]    Script Date: 3/9/2016 4:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[enrollment_date] [date] NULL,
	[department_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[students_courses]    Script Date: 3/9/2016 4:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students_courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NULL,
	[course_id] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[students_courses] ON 

INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (1, 8, 1)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (2, 9, 1)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (4, 13, 9)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (5, 14, 11)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (8, 20, 14)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (9, 21, 16)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (10, 21, 17)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (12, 25, 21)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (13, 26, 21)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (15, 30, 29)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (16, 31, 31)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (17, 31, 32)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (19, 35, 34)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (20, 36, 34)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (22, 38, 42)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (23, 39, 42)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (25, 43, 48)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (27, 44, 51)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (29, 50, 53)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (30, 51, 55)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (31, 51, 56)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (33, 55, 60)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (34, 56, 60)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (36, 60, 66)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (37, 61, 68)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (38, 61, 69)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (40, 65, 71)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (41, 66, 71)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (43, 68, 81)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (44, 69, 81)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (46, 73, 87)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (48, 74, 90)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (50, 78, 92)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (51, 79, 92)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (54, 84, 102)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (55, 84, 103)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (57, 90, 105)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (58, 91, 107)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (59, 91, 108)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (61, 95, 112)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (62, 96, 112)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (64, 100, 120)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (65, 101, 122)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (66, 101, 123)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (68, 105, 125)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (69, 106, 125)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (71, 110, 131)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (72, 111, 133)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (73, 111, 134)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (78, 118, 144)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (79, 119, 144)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (81, 123, 152)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (83, 124, 155)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (85, 128, 157)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (86, 129, 157)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (88, 133, 163)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (89, 134, 165)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (90, 134, 166)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (92, 140, 170)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (93, 141, 172)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (94, 141, 173)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (99, 148, 183)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (100, 149, 183)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (102, 153, 189)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (103, 154, 191)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (104, 154, 192)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (106, 158, 196)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (107, 159, 196)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (109, 163, 204)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (110, 164, 206)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (111, 164, 207)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (113, 168, 209)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (114, 169, 209)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (116, 173, 217)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (117, 174, 219)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (118, 174, 220)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (120, 178, 222)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (121, 179, 222)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (123, 183, 230)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (124, 184, 232)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (125, 184, 233)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (127, 190, 235)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (128, 191, 237)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (129, 191, 238)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (134, 200, 248)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (135, 201, 250)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (136, 201, 251)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (141, 210, 263)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (142, 211, 265)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (143, 211, 266)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (148, 218, 276)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (149, 219, 276)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (151, 223, 282)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (152, 224, 284)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (153, 224, 285)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (155, 228, 287)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (156, 229, 287)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (158, 233, 293)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (159, 234, 295)
GO
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (160, 234, 296)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (162, 238, 302)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (163, 239, 302)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (165, 243, 308)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (166, 244, 310)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (167, 244, 311)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (169, 250, 313)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (170, 251, 315)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (171, 251, 316)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (176, 258, 328)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (177, 259, 328)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (179, 263, 334)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (180, 264, 336)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (181, 264, 337)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (183, 268, 341)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (184, 269, 341)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (186, 273, 347)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (187, 274, 349)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (188, 274, 350)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (190, 278, 352)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (191, 279, 352)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (193, 283, 358)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (194, 284, 360)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (195, 284, 361)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (197, 288, 365)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (198, 289, 365)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (200, 293, 373)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (201, 294, 375)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (202, 294, 376)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (204, 300, 378)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (205, 301, 380)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (206, 301, 381)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (211, 310, 391)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (212, 311, 393)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (213, 311, 394)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (218, 318, 406)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (219, 319, 406)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (221, 323, 412)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (222, 324, 414)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (223, 324, 415)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (225, 330, 419)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (226, 331, 421)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (227, 331, 422)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (232, 338, 432)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (233, 339, 432)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (235, 343, 438)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (236, 344, 440)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (237, 344, 441)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (239, 348, 443)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (240, 349, 443)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (242, 353, 451)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (243, 354, 453)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (244, 354, 454)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (246, 360, 456)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (247, 361, 458)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (248, 361, 459)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (253, 370, 471)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (254, 371, 473)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (255, 371, 474)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (260, 380, 482)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (261, 381, 484)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (262, 381, 485)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (267, 390, 497)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (268, 391, 499)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (269, 391, 500)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (274, 398, 508)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (275, 399, 508)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (277, 403, 516)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (278, 404, 518)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (279, 404, 519)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (281, 410, 521)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (282, 411, 523)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (283, 411, 524)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (288, 418, 534)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (289, 419, 534)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (291, 423, 542)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (292, 424, 544)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (293, 424, 545)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (295, 430, 547)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (296, 431, 549)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (297, 431, 550)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (302, 438, 562)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (303, 439, 562)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (309, 450, 573)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (310, 451, 575)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (311, 451, 576)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (316, 460, 586)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (317, 461, 588)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (318, 461, 589)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (323, 470, 601)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (327, 475, 606)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (6, 14, 12)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (305, 443, 568)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (26, 44, 50)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (53, 83, 100)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (47, 74, 89)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (306, 444, 570)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (307, 444, 571)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (82, 124, 154)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (75, 115, 136)
GO
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (76, 116, 136)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (131, 195, 242)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (132, 196, 242)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (285, 415, 528)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (286, 416, 528)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (320, 465, 593)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (321, 466, 593)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (324, 471, 603)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (325, 471, 604)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (96, 145, 175)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (97, 146, 175)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (138, 205, 253)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (139, 206, 253)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (145, 215, 268)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (146, 216, 268)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (173, 255, 318)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (174, 256, 318)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (208, 305, 383)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (209, 306, 383)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (215, 315, 396)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (216, 316, 396)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (229, 335, 424)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (230, 336, 424)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (250, 365, 461)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (251, 366, 461)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (257, 375, 476)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (258, 376, 476)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (264, 385, 487)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (265, 386, 487)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (271, 395, 502)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (272, 396, 502)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (299, 435, 552)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (300, 436, 552)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (313, 455, 578)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (314, 456, 578)
INSERT [dbo].[students_courses] ([id], [student_id], [course_id]) VALUES (328, 476, 606)
SET IDENTITY_INSERT [dbo].[students_courses] OFF
