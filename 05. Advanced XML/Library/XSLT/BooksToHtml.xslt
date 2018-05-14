<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
				xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:msxsl="urn:schemas-microsoft-com:xslt"
				xmlns:x="http://library.by/catalog"
				xmlns:cs="http://epam.com"
				exclude-result-prefixes="msxsl"
>
	<xsl:output method="html" indent="yes"/>

	<xsl:key name="GenreGroups" match="x:genre" use="."/>

	<xsl:template match="/x:catalog">
		<xsl:text disable-output-escaping='yes'>&lt;!DOCTYPE HTML&gt;</xsl:text>
		<html>
			<head>
				<title>
					Текущие фонды по жанрам. Отчет от <xsl:value-of select="cs:CurrentDate()"/>
				</title>
			</head>
			<body>
				<h1>
					Текущие фонды по жанрам. Отчет от <xsl:value-of select="cs:CurrentDate()"/>
				</h1>
				<xsl:apply-templates select="x:book/x:genre[generate-id() = generate-id(key('GenreGroups', .)[1])]"/>
				<p>
					Всего книг в библиотеке: <xsl:value-of select="count(x:book)"/>
				</p>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="x:book/x:genre">
		<xsl:variable name="currentGroup" select="."/>
		<table width="100%" border="1" style="border-collapse: collapse">
			<caption>
				Жанр: <xsl:value-of select="$currentGroup"/>
			</caption>
			<tr>
				<th width="25%">Автор</th>
				<th width="25%">Название</th>
				<th width="25%">Дата издания</th>
				<th width="25%">Дата регистрации</th>
			</tr>
			<xsl:for-each select="key('GenreGroups', $currentGroup)">
				<tr>
					<td>
						<xsl:value-of select="../x:author"/>
					</td>
					<td>
						<xsl:value-of select="../x:title"/>
					</td>
					<td>
						<xsl:value-of select="../x:publish_date"/>
					</td>
					<td>
						<xsl:value-of select="../x:registration_date"/>
					</td>
				</tr>
			</xsl:for-each>
			<tr>
				<td colspan="4">
					Всего книг этого жанра: <xsl:value-of select="count(key('GenreGroups', $currentGroup))"/>
				</td>
			</tr>
		</table>
		<br/>
	</xsl:template>

	<msxsl:script language="C#" implements-prefix="cs">
		<![CDATA[
		public static string CurrentDate()
		{
			return DateTime.Now.ToString();
		}
		]]>
	</msxsl:script>

</xsl:stylesheet>
