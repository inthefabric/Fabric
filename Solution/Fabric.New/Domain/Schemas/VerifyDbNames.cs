
// GENERATED CODE
// Changes made to this source file will be overwritten

/*


--- VERTICES---

p (App)
p.na (Name)
p.nk (NameKey)
p.se (Secret)
p.od (OauthDomains)

a (Artifact)

c (Class)
c.na (Name)
c.nk (NameKey)
c.di (Disamb)
c.no (Note)

e (Email)
e.ad (Address)
e.co (Code)
e.ve (Verified)

f (Factor)
f.at (AssertionType)
f.de (IsDefining)
f.no (Note)
f.det (DescriptorType)
f.dit (DirectorType)
f.dip (DirectorPrimaryAction)
f.dir (DirectorRelatedAction)
f.evt (EventorType)
f.evd (EventorDateTime)
f.idt (IdentorType)
f.idv (IdentorValue)
f.lot (LocatorType)
f.lox (LocatorValueX)
f.loy (LocatorValueY)
f.loz (LocatorValueZ)
f.vet (VectorType)
f.veu (VectorUnit)
f.vep (VectorUnitPrefix)
f.vev (VectorValue)

i (Instance)
i.na (Name)
i.di (Disamb)
i.no (Note)

m (Member)
m.at (MemberType)
m.osa (OauthScopeAllow)
m.ogr (OauthGrantRedirectUri)
m.ogc (OauthGrantCode)
m.oge (OauthGrantExpires)

oa (OauthAccess)
oa.to (Token)
oa.re (Refresh)
oa.ex (Expires)
oa.co (IsClientOnly)

r (Url)
r.na (Name)
r.fp (FullPath)

u (User)
u.na (Name)
u.nk (NameKey)
u.pa (Password)

v (Vertex)
v.id (VertexId)
v.ts (Timestamp)
v.t (VertexType)


--- EDGES ---

pdm (App-Defines-Member)
pdm.ts (Defines.Timestamp)
pdm.mt (Defines.MemberType)
pdm.ui (Defines.UserId)

acbm (Artifact-CreatedBy-Member)

apbf (Artifact-UsedAsPrimaryBy-Factor)
apbf.ts (UsedAsPrimaryBy.Timestamp)
apbf.dt (UsedAsPrimaryBy.DesdcriptorType)
apbf.ra (UsedAsPrimaryBy.RelatedArtifactId)

arbf (Artifact-UsedAsRelatedBy-Factor)
arbf.ts (UsedAsRelatedBy.Timestamp)
arbf.dt (UsedAsRelatedBy.DesdcriptorType)
arbf.pa (UsedAsRelatedBy.PrimaryArtifactId)

fcbm (Factor-CreatedBy-Member)

frpa (Factor-DescriptorRefinesPrimaryWith-Artifact)

frra (Factor-DescriptorRefinesRelatedWith-Artifact)

frta (Factor-DescriptorRefinesTypeWith-Artifact)

fpa (Factor-UsesPrimary-Artifact)

fra (Factor-UsesRelated-Artifact)

faa (Factor-VectorUsesAxis-Artifact)

mca (Member-Creates-Artifact)
mca.ts (Creates.Timestamp)
mca.vt (Creates.VertexType)

mcf (Member-Creates-Factor)
mcf.ts (Creates.Timestamp)
mcf.dt (Creates.DescriptorType)
mcf.pa (Creates.PrimaryArtifactId)
mcf.ra (Creates.RelatedArtifactId)

mdbp (Member-DefinedBy-App)

mdbu (Member-DefinedBy-User)

udm (User-Defines-Member)
udm.ts (Defines.Timestamp)
udm.mt (Defines.MemberType)
udm.pi (Defines.AppId)

*/