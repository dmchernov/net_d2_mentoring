<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:msxsl="urn:schemas-microsoft-com:xslt"
				xmlns:x="http://library.by/catalog"
				xmlns:cs="http://epam.com"
				exclude-result-prefixes="msxsl">
	<xsl:output method="xml" indent="yes"/>

	<xsl:template match="@* | node()">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()"/>
		</xsl:copy>
	</xsl:template>

  <xsl:template match="x:catalog">
	<xsl:element name="rss">
	  <xsl:attribute name="version">
		<xsl:text>2.0</xsl:text>
	  </xsl:attribute>
	  <xsl:element name="channel">
		<xsl:element name="title">
		  <xsl:text>Books RSS</xsl:text>
		</xsl:element>
		  <xsl:apply-templates select="x:book"></xsl:apply-templates>
	  </xsl:element>
	</xsl:element>
  </xsl:template>

	<xsl:template match="x:book">
	  <xsl:element name="item">
		  <xsl:element name="title">
			<xsl:value-of select="x:title"/>
		  </xsl:element>
		<xsl:element name="link">
			<xsl:if test="(x:genre='Computer') and (x:isbn)">
			  <xsl:value-of select="concat('http://my.safaribooksonline.com/', x:isbn, '/')"/>
			</xsl:if>
			<xsl:if test="x:genre!='Computer'">
				<xsl:value-of select="concat('http://mysite.com/', x:title)"/>
			</xsl:if>
		</xsl:element>
		<xsl:element name="description">
		  <xsl:value-of select="x:description"/>
		</xsl:element>
		<xsl:element name="pubDate">
		  <xsl:value-of select="x:registration_date"/>
		</xsl:element>
		<xsl:element name="guid">
		  <xsl:value-of select="cs:NewGuid()"/>
		</xsl:element>
	  </xsl:element>
	</xsl:template>

  <msxsl:script language="C#" implements-prefix="cs">
	  <![CDATA[
		public static string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }
		]]>
  </msxsl:script>

</xsl:stylesheet>
